import matplotlib.pyplot as plt
import sys
import re
import os


def plot_full_batch23(batch):
    fig, axs = plt.subplots(2, 3, squeeze=False)
    for i, res in enumerate(batch):
        with open(res, 'r') as file:
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

        axs[int(i / 3), i % 3].plot(iterations, min_cycle_lengths,
                                    label='best chromosome', c='tab:orange')
        axs[int(i / 3), i % 3].plot(iterations, avg_cycle_legnths,
                                    label='population average', c='tab:blue')
        title = '\n'.join(lines[0].split('&'))
        axs[int(i / 3), i % 3].set_title(title)
        axs[int(i / 3), i % 3].legend(loc='upper right')

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
