import matplotlib.pyplot as plt
from scipy import stats


def print_points_graph(numbers_list: list) -> None:
    x = range(1, len(numbers_list) + 1)
    y = numbers_list

    slope, intercept, r, p, std_err = stats.linregress(x, y)

    def myfunc(x):
        return slope * x + intercept

    mymodel = list(map(myfunc, x))

    plt.scatter(x, y)
    plt.plot(x, mymodel)
    plt.show()
