#### A sample GUID
`cd26ccf6-75d6-4521-884f-1693c62ed303`

Shifts bits from left to right by 4, adding zeros to the left hand of the shifted bits
`int highNibble = bytes[i] >> 0b100;`

Logical AND the bytes with 00001111, this essentially discards the first 4 bits and preserves the last 4 bits
`int lowNibble = bytes[i] & 0b1111;`

Add highNibble or lowNibble to the sum if they are <10

#### Breaking down step by step foreach byte in our array
    *cd* - 11001101 
    -> HNibble : 00001100 -> 12
    -> LNibble : 00001101 -> 13
    26 - 00100110
    -> HNibble : 00000010 -> 2
    -> LNibble : 00000110 -> 6
    cc - 11001100
    -> HNibble : 00001100 -> 12
    -> LNibble : 00001100 -> 12
    f6 - 11110110
    -> HNibble : 00001111 -> 15
    -> LNibble : 00000110 -> 6
    75 - 01110101
    -> HNibble : 00000111 -> 7
    -> LNibble : 00000101 -> 5
    d6 - 11010110
    -> HNibble : 00001101 -> 13
    -> LNibble : 00000110 -> 6
    45 - 01000101
    -> HNibble : 00000100 -> 4
    -> LNibble : 00000101 -> 5
    21 - 00100001
    -> HNibble : 00000010 -> 2
    -> LNibble : 00000001 -> 1
    88 - 10001000
    -> HNibble : 00001000 -> 8
    -> LNibble : 00001000 -> 8
    4f - 01001111
    -> HNibble : 00000100 -> 4
    -> LNibble : 00001111 -> 15
    16 - 00010110
    -> HNibble : 00000001 -> 1
    -> LNibble : 00000110 -> 6
    93 - 10010011
    -> HNibble : 00001001 -> 9
    -> LNibble : 00000011 -> 3
    c6 - 11000110
    -> HNibble : 00001100 -> 12
    -> LNibble : 00000110 -> 6
    2e - 00101110
    -> HNibble : 00000010 -> 2
    -> LNibble : 00001110 -> 14
    d3 - 11010011
    -> HNibble : 00001101 -> 13
    -> LNibble : 00000011 -> 3
    03 - 00000011
    -> HNibble : 00000000 -> 0
    -> LNibble : 00000011 -> 3

     The sum of which is 97 .
