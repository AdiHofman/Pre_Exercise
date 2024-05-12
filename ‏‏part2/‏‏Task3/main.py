def is_sorted_polyndrom(text: str) -> bool:
    half_len = len(text) // 2
    first_part = text[:half_len]
    second_part = text[-1:-1 * half_len - 1:-1]

    if first_part != second_part:
        return False

    if len(text) % 2 == 0:
        sorted_part = ''.join(sorted(first_part))
        if sorted_part != first_part:
            return False
    else:
        half_text = text[:half_len + 1]
        sorted_part = ''.join(sorted(half_text))
        if sorted_part != half_text:
            return False

    return True


if __name__ == '__main__':
    print(is_sorted_polyndrom("abcdcba"))
    print(is_sorted_polyndrom("אבגדגבא"))
    print(is_sorted_polyndrom("דגבאבגד"))
    print(is_sorted_polyndrom("123565321"))
