using TravelingSalesman.Mutations;
using TravelingSalesman.Utils;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Data;
using TravelingSalesman.TSPFitness;
using TravelingSalesman.Factories;
using TravelingSalesman.Algorithms;

namespace TravelingSalesmanGUI
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Point> points;
        SolidBrush brush;
        Pen pen;
        int size = 10;

        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            canvas.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            points = new List<Point>();
            brush = new SolidBrush(Color.Black);
            pen = new Pen(Color.Red);

            Random rand = new Random();
            SetUpMutations(rand);
            SetUpMating(rand);
        }

        private void SetUpMutations(Random rand)
        {
            mutationComboBox.Items.Add(new CenterInverseMutation(rand));
            mutationComboBox.Items.Add(new PartialShuffleMutation());
            mutationComboBox.Items.Add(new ReverseSequenceMutation(rand));
            mutationComboBox.Items.Add(new ThorasMutation(rand));
            mutationComboBox.Items.Add(new ThorosMutation(new KnuthArrayShuffler(rand)));
            mutationComboBox.Items.Add(new TworsMutation(rand));
        }

        private void SetUpMating(Random rand)
        {
            matingComboBox.Items.Add(new PartiallyMappedX(rand));
            matingComboBox.Items.Add(new CycleX());
            matingComboBox.Items.Add(new OrderX(rand));
            matingComboBox.Items.Add(new OrderX2(rand));
        }

        private void DrawCircle(Point location) => graphics.FillEllipse(brush, location.X - size / 2, location.Y - size / 2, size, size);

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            DrawCircle(e.Location);
            canvas.Refresh();
        }

        private void DrawLines(int[] vertexes)
        {
            for (int i = 1; i < vertexes.Length; i++)
            {
                graphics.DrawLine(pen, points[vertexes[i]], points[vertexes[i - 1]]);
            }

            graphics.DrawLine(pen, points[vertexes[0]], points[vertexes[^1]]);
        }

        private void DrawVertexes()
        {
            foreach (var vertex in points)
            {
                DrawCircle(vertex);
            }
        }

        private void Draw(int[] vertexes)
        {
            graphics.Clear(Color.White);
            DrawLines(vertexes);
            DrawVertexes();
            canvas.Refresh();
        }    

        private void runButton_Click(object sender, EventArgs e)
        {
            Graph graph = Utils.GetGraph(points.ToArray());

            Random rand = new Random();

            var chromosomeFactory = new TSPChromosomeFactory(rand);
            var matingStrategy = (MatingStrategy)matingComboBox.Items[matingComboBox.SelectedIndex];
            var mutation = (Mutation)mutationComboBox.Items[mutationComboBox.SelectedIndex];
            var fitnessCalculator = new TSPFitnessCalculator(graph);
            var populationSize = (int)populationUpDown.Value;
            var maxIterations = (int)maxIterationUpDown.Value;
            var matingProbability = (double)matingProbUpDown.Value;
            var mutationProbability = (double)mutationProbUpDown.Value;

            GeneticAlgorithm algorithm = new GeneticAlgorithm(graph.Length, populationSize, 
                chromosomeFactory, matingStrategy, mutation, fitnessCalculator);

            string logPath = Path.Combine(@"../../../../Results/", DateTime.Now.Ticks.ToString() + ".txt");
            algorithm.LogPath = logPath;
            algorithm.Run(maxIterations, matingProbability, mutationProbability);

            int[] genomes = algorithm.GetShortestCycleChromosome().Item1.Genomes;

            Draw(genomes);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            graphics.Clear(Color.White);
            canvas.Refresh();
        }
    }
}