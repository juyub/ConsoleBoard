/*
CREATE TABLE c_board_test (
    BoardNo NUMBER(10) PRIMARY KEY,
    TITLE VARCHAR2(100),
    CONTENT VARCHAR2(4000),
    RegDate DATE
);

CREATE SEQUENCE c_board_test_seq
START WITH     1
INCREMENT BY   1
NOCACHE;
*/

public class Board
{
    public int boardNo { get; set; }
    public string title { get; set; }
    public string content { get; set; }

    public DateTime regDate { get; set; }
}