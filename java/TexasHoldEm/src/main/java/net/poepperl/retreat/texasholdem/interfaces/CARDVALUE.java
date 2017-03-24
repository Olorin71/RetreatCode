package net.poepperl.retreat.texasholdem.interfaces;

public enum CARDVALUE {
    ACE(14), KING(13), QUEEN(12), JACK(11), TEN(10), NINE(9), EIGHT(8), SEVEN(7), SIX(6), FIVE(5), FOUR(4), THREE(
            3), TWO(2);

    private final int value;

    CARDVALUE(final int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    public String toString() {
        switch (value) {
        case 14:
            return "Ace";
        case 13:
            return "King";
        case 12:
            return "Queen";
        case 11:
            return "Jack";
        case 10:
            return "Ten";
        case 9:
            return "Nine";
        case 8:
            return "Eight";
        case 7:
            return "Seven";
        case 6:
            return "Six";
        case 5:
            return "Five";
        case 4:
            return "Four";
        case 3:
            return "Three";
        case 2:
            return "Two";
        }
        return "";
    }
}
