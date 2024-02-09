# Supermarket Checkout Test Specifications

## Test Case  1: Empty Checkout
**Test Name:** Calculate Total Price for No Items
**Given:** The input string is empty (`""`)
**When:** The `Price` function is called with the empty string
**Then:** The output should be `0`, indicating that the total price for no items is zero

## Test Case  2: Single Item
**Test Name:** Calculate Total Price for One Item A
**Given:** The input string contains one 'A' (`"A"`)
**When:** The `Price` function is called with the string `"A"`
**Then:** The output should be `50`, indicating that the total price for one 'A' is £50

## Test Case  3: Two Different Items
**Test Name:** Calculate Total Price for Two Different Items AB
**Given:** The input string contains two different items 'A' and 'B' (`"AB"`)
**When:** The `Price` function is called with the string `"AB"`
**Then:** The output should be `80`, indicating that the total price for one 'A' and one 'B' is £80

## Test Case  4: Multiple Items with Offers
**Test Name:** Calculate Total Price for Various Items with Offers
**Given:** The input string contains four different items 'A', 'B', 'C', and 'D' (`"CDBA"`)
**When:** The `Price` function is called with the string `"CDBA"`
**Then:** The output should be `115`, indicating that the total price for one 'C', one 'D', one 'B', and one 'A' with the applicable offers is £115

## Test Case  5: Applying Offers
**Test Name:** Calculate Total Price with Applied Offers
**Given:** The input string contains four 'A' items (`"AAAA"`)
**When:** The `Price` function is called with the string `"AAAA"`
**Then:** The output should be `130`, indicating that the total price for four 'A' items with the special offer applied is £130
