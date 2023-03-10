using TravelingSalesman.MatingStrategies;

namespace Tests.MatingStrategies
{
    public class OrdinalRepresentationConverterTest
    {
        public static IEnumerable<object[]> TestDataToOrd()
        {
            yield return new object[] {
                new int[] { 0, 0, 2, 2, 1, 0, 1, 0 },
                new int[] { 1, 2, 5, 6, 4, 3, 8, 7 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8 } };
        }

        public static IEnumerable<object[]> TestDataFromOrd()
        {
            yield return new object[] {
                new int[] { 1, 2, 5, 6, 4, 3, 8, 7 },
                new int[] { 0, 0, 2, 2, 1, 0, 1, 0 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8 } };
        }

        [Theory]
        [MemberData(nameof(TestDataToOrd))]
        public void TestConvertionToOrdinalRepresentation(int[] expected, int[] route, int[] canonicRoute)
        {
            var ordinalRepresentation = OrdinalRepresentaion.ToOrd(route, canonicRoute);

            Assert.Equal(expected, ordinalRepresentation);
        }

        [Theory]
        [MemberData(nameof(TestDataFromOrd))]
        public void TestConvertionFromOrdinalRepresentation(int[] expected, int[] ordinalRep, int[] canonicRoute)
        {
            var route = OrdinalRepresentaion.FromOrd(ordinalRep, canonicRoute);

            Assert.Equal(expected, route);
        }
    }
}
