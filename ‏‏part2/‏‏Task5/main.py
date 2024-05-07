import math_pi


def reverse_n_pi_digits(n: int) -> str:
    pie = str(math_pi.pi(b=n - 1))
    reversed_pie = pie[::-1]
    return reversed_pie


if __name__ == '__main__':
    print(reverse_n_pi_digits(20))
