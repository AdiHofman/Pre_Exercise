from itertools import combinations


def pythagorean_triplet_by_sum(sum_numbers: int) -> None:
    vals_list = range(1, sum_numbers)
    sum_combinations = ['<'.join(map(str, sorted(pair))) for pair in combinations(vals_list, 3) if
                        sum(pair) == sum_numbers and is_pythagorean_triple(pair)]

    printed_sum_combinations = ' , '.join(sum_combinations)
    print(printed_sum_combinations)


def is_pythagorean_triple(pair: list) -> bool:
    a = pair[0]
    b = pair[1]
    c = pair[2]
    if a ** 2 == b ** 2 + c ** 2 or b ** 2 == a ** 2 + c ** 2 or c ** 2 == a ** 2 + b ** 2:
        return True

    return False


if __name__ == '__main__':
    pythagorean_triplet_by_sum(56)
    # pythagorean_triplet_by_sum(540)
