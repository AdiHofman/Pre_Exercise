def take_numbers_list_from_user() -> list:
    input_number = 0
    numbers_list = []
    while input_number != -1:
        input_number = input("Please enter a number: ").strip()
        checked_input = input_number.replace('-', '')
        checked_input = checked_input.replace('.', '')
        if checked_input.isnumeric():
            input_number = float(input_number)
            if input_number != -1:
                numbers_list.append(input_number)

    return numbers_list
