import math


def num_len(num: int) -> int:
    return math.floor(math.log10(num) + 1)


if __name__ == '__main__':
    number = 43132
    print(f"The length of {number} is {num_len(number)}")
