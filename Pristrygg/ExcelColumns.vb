Public Class ExcelColumns
    Private ColumnArray() As String
    Private Const m_MaxColumns As Long = 180

    Public Sub InitArray()

        ReDim ColumnArray(m_MaxColumns)

        ColumnArray(1) = "A"
        ColumnArray(2) = "B"
        ColumnArray(3) = "C"
        ColumnArray(4) = "D"
        ColumnArray(5) = "E"
        ColumnArray(6) = "F"
        ColumnArray(7) = "G"
        ColumnArray(8) = "H"
        ColumnArray(9) = "I"
        ColumnArray(10) = "J"
        ColumnArray(11) = "K"
        ColumnArray(12) = "L"
        ColumnArray(13) = "M"
        ColumnArray(14) = "N"
        ColumnArray(15) = "O"
        ColumnArray(16) = "P"
        ColumnArray(17) = "Q"
        ColumnArray(18) = "R"
        ColumnArray(19) = "S"
        ColumnArray(20) = "T"
        ColumnArray(21) = "U"
        ColumnArray(22) = "V"
        ColumnArray(23) = "W"
        ColumnArray(24) = "X"
        ColumnArray(25) = "Y"
        ColumnArray(26) = "Z"

        ColumnArray(27) = "AA"
        ColumnArray(28) = "AB"
        ColumnArray(29) = "AC"
        ColumnArray(30) = "AD"
        ColumnArray(31) = "AE"
        ColumnArray(32) = "AF"
        ColumnArray(33) = "AG"
        ColumnArray(34) = "AH"
        ColumnArray(35) = "AI"
        ColumnArray(36) = "AJ"
        ColumnArray(37) = "AK"
        ColumnArray(38) = "AL"
        ColumnArray(39) = "AM"
        ColumnArray(40) = "AN"
        ColumnArray(41) = "AO"
        ColumnArray(42) = "AP"
        ColumnArray(43) = "AQ"
        ColumnArray(44) = "AR"
        ColumnArray(45) = "AS"
        ColumnArray(46) = "AT"
        ColumnArray(47) = "AU"
        ColumnArray(48) = "AV"
        ColumnArray(49) = "AW"
        ColumnArray(50) = "AX"
        ColumnArray(51) = "AY"
        ColumnArray(52) = "AZ"

        ColumnArray(53) = "BA"
        ColumnArray(54) = "BB"
        ColumnArray(55) = "BC"
        ColumnArray(56) = "BD"
        ColumnArray(57) = "BE"
        ColumnArray(58) = "BF"
        ColumnArray(59) = "BG"
        ColumnArray(60) = "BH"
        ColumnArray(61) = "BI"
        ColumnArray(62) = "BJ"
        ColumnArray(63) = "BK"
        ColumnArray(64) = "BL"
        ColumnArray(65) = "BM"
        ColumnArray(66) = "BN"
        ColumnArray(67) = "BO"
        ColumnArray(68) = "BP"
        ColumnArray(69) = "BQ"
        ColumnArray(70) = "BR"
        ColumnArray(71) = "BS"
        ColumnArray(72) = "BT"
        ColumnArray(73) = "BU"
        ColumnArray(74) = "BV"
        ColumnArray(75) = "BW"
        ColumnArray(76) = "BX"
        ColumnArray(77) = "BY"
        ColumnArray(78) = "BZ"

        ColumnArray(79) = "CA"
        ColumnArray(80) = "CB"
        ColumnArray(81) = "CC"
        ColumnArray(82) = "CD"
        ColumnArray(83) = "CE"
        ColumnArray(84) = "CF"
        ColumnArray(85) = "CG"
        ColumnArray(86) = "CH"
        ColumnArray(87) = "CI"
        ColumnArray(88) = "CJ"
        ColumnArray(89) = "CK"
        ColumnArray(90) = "CL"
        ColumnArray(91) = "CM"
        ColumnArray(92) = "CN"
        ColumnArray(93) = "CO"
        ColumnArray(94) = "CP"
        ColumnArray(95) = "CQ"
        ColumnArray(96) = "CR"
        ColumnArray(97) = "CS"
        ColumnArray(98) = "CT"
        ColumnArray(99) = "CU"
        ColumnArray(100) = "CV"
        ColumnArray(101) = "CW"
        ColumnArray(102) = "CX"
        ColumnArray(103) = "CY"
        ColumnArray(104) = "CZ"


        '--->2006-05-18, lägger till några till...
        ColumnArray(105) = "DA"
        ColumnArray(106) = "DB"
        ColumnArray(107) = "DC"
        ColumnArray(108) = "DD"
        ColumnArray(109) = "DE"
        ColumnArray(110) = "DF"
        ColumnArray(111) = "DG"
        ColumnArray(112) = "DH"
        ColumnArray(113) = "DI"
        ColumnArray(114) = "DJ"
        ColumnArray(115) = "DK"
        ColumnArray(116) = "DL"
        ColumnArray(117) = "DM"
        ColumnArray(118) = "DN"
        ColumnArray(119) = "DO"
        ColumnArray(120) = "DP"
        ColumnArray(121) = "DQ"
        ColumnArray(122) = "DR"
        ColumnArray(123) = "DS"
        ColumnArray(124) = "DT"
        ColumnArray(125) = "DU"
        ColumnArray(126) = "DV"
        ColumnArray(127) = "DW"
        ColumnArray(128) = "DX"
        ColumnArray(129) = "DY"
        ColumnArray(130) = "DZ"

        ColumnArray(131) = "EA"
        ColumnArray(132) = "EB"
        ColumnArray(133) = "EC"
        ColumnArray(134) = "ED"
        ColumnArray(135) = "EE"
        ColumnArray(136) = "EF"
        ColumnArray(137) = "EG"
        ColumnArray(138) = "EH"
        ColumnArray(139) = "EI"
        ColumnArray(140) = "EJ"
        ColumnArray(141) = "EK"
        ColumnArray(142) = "EL"
        ColumnArray(143) = "EM"
        ColumnArray(144) = "EN"
        ColumnArray(145) = "EO"
        ColumnArray(146) = "EP"
        ColumnArray(147) = "EQ"
        ColumnArray(148) = "ER"
        ColumnArray(149) = "ES"
        ColumnArray(150) = "ET"
        ColumnArray(151) = "EU"
        ColumnArray(152) = "EV"
        ColumnArray(153) = "EW"
        ColumnArray(154) = "EX"
        ColumnArray(155) = "EY"
        ColumnArray(156) = "EZ"

        ColumnArray(157) = "FA"
        ColumnArray(158) = "FB"
        ColumnArray(159) = "FC"
        ColumnArray(160) = "FD"
        ColumnArray(161) = "FE"
        ColumnArray(162) = "FF"
        ColumnArray(163) = "FG"
        ColumnArray(164) = "FH"
        ColumnArray(165) = "FI"
        ColumnArray(166) = "FJ"
        ColumnArray(167) = "FK"
        ColumnArray(168) = "FL"
        ColumnArray(169) = "FM"
        ColumnArray(170) = "FN"
        ColumnArray(171) = "FO"
        ColumnArray(172) = "FP"
        ColumnArray(173) = "FQ"
        ColumnArray(174) = "FR"
        ColumnArray(175) = "FS"
        ColumnArray(176) = "FT"
        ColumnArray(177) = "FU"
        ColumnArray(178) = "FV"
        ColumnArray(179) = "FW"
        ColumnArray(180) = "FX"
        'ColumnArray(181) = "FY"
        'ColumnArray(182) = "FZ"


    End Sub

    Public Function ReplaceLetterWithDigit(sLetter As String) As Long
        Dim J As Long

        ReplaceLetterWithDigit = 0

        For J = 1 To m_MaxColumns

            If ColumnArray(J) = sLetter Then
                ReplaceLetterWithDigit = J
                Exit For
            End If

        Next J

    End Function

    Public Function ReplaceDigitWithLetter(sDigit As Long) As String

        If sDigit > m_MaxColumns Then
            ReplaceDigitWithLetter = ""
        Else
            ReplaceDigitWithLetter = ColumnArray(sDigit)
        End If

    End Function

End Class
