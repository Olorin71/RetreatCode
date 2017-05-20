package net.poepperl.retreat.texasholdem.interfaces;

public enum CARDVALUE {
    ACE(14), KING(13), QUEEN(12), JACK(11), TEN(10), NINE(9), EIGHT(8), SEVEN(7), SIX(6), FIVE(5), FOUR(4), THREE(
            3), TWO(2), ACEASONE(1);
    // todo: logik für aceasone in die checker verschieben und da eine "Sonderbehandlung"
    // todo: reihenfolge umdrehen, damit previous und next funktionierens
    
    private final int value;

    CARDVALUE(final int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    public CARDVALUE previous() {
        // values are ordered descending so previous is ordinal + 1 and vice
        // versa
        if (ordinal() + 1 == values().length)
            return null;

        return values()[ordinal() + 1];
    }

    public CARDVALUE next() {
        // values are ordered descending so next is ordinal - 1 and vice
        // versa
        if (ordinal() == 0)
            return null;

        return values()[ordinal() - 1];
    }

    public String toString() {
        switch (value) {
        case 14:
        case 1:
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
