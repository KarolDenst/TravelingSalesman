import matplotlib.pyplot as plt
import sys
import re

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('Invalid arguments')
        sys.exit(1)

    path = sys.argv[1]
    with open(path, 'r') as file:
        lines = [line.rstrip() for line in file]

    values = []
    for line in lines:
        m = re.search(r'>(.+)', line)
        if m:
            found = m.group(1)
            values.append(float(found))

    plt.plot(list(range(len(values))), values)
    plt.title(sys.argv[2])
    plt.xlabel("Iteration")
    plt.ylabel("Cycle length")
    plt.show()
