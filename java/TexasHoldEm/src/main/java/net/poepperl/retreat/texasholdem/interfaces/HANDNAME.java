package net.poepperl.retreat.texasholdem.interfaces;

public enum HANDNAME {
    ROYALFLUSH(10),
    STRAIGHTFLUSH(9),
    FOUROFAKIND(8),
    FULLHOUSE(7),
    FLUSH(6),
    STRAIGHT(5),
    THREEOFAKIND(4),
    TWOPAIRS(3),
    PAIR(2),
    HIGHCARD(1);

    private final int value;

    HANDNAME(final int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    public String toString() {
        switch (value){
        case 10:
            return "Royal Flush";
        case 9:
            return "Straight Flush";
        case 8:
            return "four of a kind";
        case 7:
            return "Full House";
        case 6:
            return "Flush";
        case 5:
            return "Straight";
        case 4:
            return "three of a Kind";
        case 3:
            return "two pairs";
        case 2:
            return "pair";
        default:
            return "high Card";
        }
    }
}
