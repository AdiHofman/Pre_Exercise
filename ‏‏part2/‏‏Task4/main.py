import statistics
from show_points_graph import print_points_graph
from get_numbers_list_from_user import take_numbers_list_from_user


def main() -> None:
    numbers_list = take_numbers_list_from_user()

    numbers_average = statistics.mean(numbers_list)
    print(f"The average of {str(numbers_list)} is {numbers_average}")

    positive_amount = len([num for num in numbers_list if num > 0])
    print(f"The amount of positive numbers in {str(numbers_list)} is {positive_amount}")

    sorted_numbers_list = sorted(numbers_list)
    print(f"The sorted list:  {sorted_numbers_list}")

    print_points_graph(numbers_list)


if __name__ == '__main__':
    main()
