import matplotlib.pyplot as plt
import sys
import re

def plot_full_batch23(path):
    with open(path, 'r') as file:
        lines = [line.rstrip() for line in file]
        iterations = []
        min_cycle_lengths = []
        avg_cycle_legnths = []
        for line in lines[1:]:
            m = re.findall(r'(\w+)\s*=\s*(.+?);', line)
            for group in m:
                k, v = group
                if k == 'it':
                    iterations.append(int(v))
                elif k == 'min':
                    min_cycle_lengths.append(float(v))
                elif k == 'avg':
                    avg_cycle_legnths.append(float(v))
                else:
                    pass

    plt.plot(iterations, min_cycle_lengths,
                                label='best chromosome', c='tab:orange')
    plt.plot(iterations, avg_cycle_legnths,
                                label='population average', c='tab:blue')
    plt.title(lines[0])
    plt.legend(loc='upper right')


if len(sys.argv) != 2:
    print('Invalid arguments')
    sys.exit(1)

path = sys.argv[1]
plot_full_batch23(path)

plt.show()
