def take_numbers_list_from_user() -> list:
    input_number = 0
    numbers_list = []
    while input_number != -1:
        input_number = input("Please enter a number: ").strip()
        if input_number.replace('-', '').isnumeric():
            input_number = int(input_number)
            if input_number != -1:
                numbers_list.append(input_number)

    return numbers_list
