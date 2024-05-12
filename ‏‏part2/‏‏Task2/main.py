from itertools import combinations


def pythagorean_triplet_by_sum(sum_numbers: int) -> None:
    if type(sum_numbers) is not int:
        return

    vals_list = range(1, sum_numbers)
    sum_combinations = ['<'.join(map(str, pair)) for pair in combinations(vals_list, 3) if
                        sum(pair) == sum_numbers and is_pythagorean_triple(pair)]

    printed_sum_combinations = ' , '.join(sum_combinations)
    print(printed_sum_combinations)


def is_pythagorean_triple(pair: list) -> bool:
    pair = sorted(pair)
    if pair[2] ** 2 == pair[0] ** 2 + pair[1] ** 2:
        return True

    return False


if __name__ == '__main__':
    pythagorean_triplet_by_sum(24)
    # pythagorean_triplet_by_sum(600)
