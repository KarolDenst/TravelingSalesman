import matplotlib.pyplot as plt
import sys
import re
import os


def plot_full_batch23(batch):
    fig, axs = plt.subplots(2, 3, squeeze=False)
    for i, res in enumerate(batch):
        with open(res, 'r') as file:
            lines = [line.rstrip() for line in file]
            values = []
            for line in lines[1:]:
                m = re.search(r'>(.+)', line)
                if m:
                    found = m.group(1)
                    values.append(float(found))

        axs[int(i / 3), i % 3].plot(list(range(len(values))), values)
        axs[int(i / 3), i % 3].set_title(lines[0])

    for ax in axs.flat:
        ax.set(xlabel='iteration', ylabel='cycle length')

    for ax in axs.flat:
        ax.label_outer()


if len(sys.argv) != 2:
    print('Invalid arguments')
    sys.exit(1)

path_to_dir = sys.argv[1]
dir = os.fsencode(path_to_dir)
full_paths = [os.path.join(path_to_dir, os.fsdecode(file))
              for file in os.listdir(dir) if os.fsdecode(file).endswith(".txt")]

plot_full_batch23(full_paths)

plt.show()
