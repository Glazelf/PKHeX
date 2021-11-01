﻿using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    public static partial class Legal
    {
        // Current Binaries
        internal const int MaxSpeciesID_8 = MaxSpeciesID_8_R2;
        internal const int MaxMoveID_8 = MaxMoveID_8_R2;
        internal const int MaxItemID_8 = MaxItemID_8_R2;
        internal const int MaxAbilityID_8 = MaxAbilityID_8_R2;

        // Orion (No DLC)
        internal const int MaxSpeciesID_8_O0 = 890; // Eternatus
        internal const int MaxMoveID_8_O0 = 796; // Steel Beam
        internal const int MaxItemID_8_O0 = 1278; // Rotom Catalog, ignore all catalog parts
        internal const int MaxAbilityID_8_O0 = 258; // Hunger Switch

        // Rigel 1 (DLC 1: Isle of Armor)
        internal const int MaxSpeciesID_8_R1 = 893; // Zarude
        internal const int MaxMoveID_8_R1 = 818; // Surging Strikes
        internal const int MaxItemID_8_R1 = 1589; // Mark Charm
        internal const int MaxAbilityID_8_R1 = 260; // Unseen Fist

        // Rigel 2 (DLC 2: Crown Tundra)
        internal const int MaxSpeciesID_8_R2 = 898; // Calyrex
        internal const int MaxMoveID_8_R2 = 826; // Eerie Spell
        internal const int MaxItemID_8_R2 = 1607; // Reins of Unity
        internal const int MaxAbilityID_8_R2 = 267; // As One (Glastrier)

        internal const int MaxBallID_8 = 0x1A; // 26 Beast
        internal const int MaxGameID_8 = 45; // Shield

        #region Met Locations
        internal static readonly int[] Met_SWSH_0 =
        {
                 002, 004, 006, 008,
                 012, 014, 016, 018,
            020, 022, 024,      028,
            030, 032, 034, 036,
            040,      044, 046, 048,
            052, 054, 056, 058,
            060,      064, 066, 068,
            070, 072,      076, 078,
            080,      084, 086, 088,
            090, 092, 094, 096, 098,
                 102, 104, 106, 108,
            110, 112, 114, 116, 118,
            120, 122, 124, 126, 128,
            130, 132, 134, 136, 138,
            140, 142, 144, 146, 148,
            150, 152, 154, 156, 158,
            160, 162, 164, 166, 168,
            170, 172, 174, 176, 178,
            180, 182, 184, 186, 188,
            190, 192, 194, 196, 198,
            200, 202,

                      204, 206, 208,
            210, 212, 214, 216, 218,
            220, 222, 224, 226, 228,
            230, 232, 234, 236, 238,
            240, 242, 244, 246,
        };

        internal static readonly int[] Met_SWSH_3 =
        {
            30001, 30003, 30004, 30005, 30006, 30007, 30008, 30009, 30010, 30011, 30012, 30013, 30014, 30015, 30016, 30017, 30018,
        };

        internal static readonly int[] Met_SWSH_4 =
        {
            40001, 40002, 40003,        40005, 40006, 40007, 40008, 40009, 40010,
            40011, 40012, 40013, 40014,        40016, 40017, 40018, 40019, 40020,
            40021, 40022,        40024, 40025, 40026, 40027, 40028, 40029, 40030,
                   40032, 40033, 40034, 40035, 40036, 40037, 40038, 40039, 40040,
            40041, 40042, 40043, 40044, 40045,        40047, 40048, 40049, 40050,
            40051, 40052, 40053,        40055, 40056, 40057, 40058, 40059, 40060,
            40061,        40063, 40064, 40065, 40066, 40067, 40068, 40069, 40070,
            40071, 40072,        40074, 40075, 40076, 40077, 40078, 40079, 40080,
            40081, 40082, 40083, 40084, 40085, 40086,
        };

        internal static readonly int[] Met_SWSH_6 = {/* XY */ 60001, 60003, /* ORAS */ 60004 };
        #endregion

        internal static readonly ushort[] Pouch_Regular_SWSH =
        {
            045, 046, 047, 048, 049, 050, 051, 052, 053, 076, 077, 079, 080, 081, 082, 083, 084, 085, 107, 108, 109,
            110, 112, 116, 117, 118, 119, 135, 136, 213, 214, 215, 217, 218, 219, 220, 221, 222, 223, 224, 225, 228,
            229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
            250, 251, 252, 253, 254, 255, 257, 258, 259, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276,
            277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297,
            298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 315, 316, 317, 318,
            319, 320, 321, 322, 323, 324, 325, 326, 485, 486, 487, 488, 489, 490, 491, 537, 538, 539, 540, 541, 542,
            543, 544, 545, 546, 547, 564, 565, 566, 567, 568, 569, 570, 639, 640, 644, 645, 646, 647, 648, 649, 650,
            846, 849, 879, 880, 881, 882, 883, 884, 904, 905, 906, 907, 908, 909, 910, 911, 912, 913, 914, 915, 916,
            917, 918, 919, 920, 1103, 1104, 1109, 1110, 1111, 1112, 1113, 1114, 1115, 1116, 1117, 1118, 1119, 1120,
            1121, 1122, 1123, 1124, 1125, 1126, 1127, 1128, 1129, 1231, 1232, 1233, 1234, 1235, 1236, 1237, 1238, 1239,
            1240, 1241, 1242, 1243, 1244, 1245, 1246, 1247, 1248, 1249, 1250, 1251, 1252, 1253, 1254,

            1279,
            1280, 1281, 1282, 1283, 1284, 1285, 1286, 1287, 1288, 1289, 1290, 1291, 1292, 1293, 1294, 1295, 1296, 1297,
            1298, 1299, 1300, 1301, 1302, 1303, 1304, 1305, 1306, 1307, 1308, 1309, 1310, 1311, 1312, 1313, 1314, 1315,
            1316, 1317, 1318, 1319, 1320, 1321, 1322, 1323, 1324, 1325, 1326, 1327, 1328, 1329, 1330, 1331, 1332, 1333,
            1334, 1335, 1336, 1337, 1338, 1339, 1340, 1341, 1342, 1343, 1344, 1345, 1346, 1347, 1348, 1349, 1350, 1351,
            1352, 1353, 1354, 1355, 1356, 1357, 1358, 1359, 1360, 1361, 1362, 1363, 1364, 1365, 1366, 1367, 1368, 1369,
            1370, 1371, 1372, 1373, 1374, 1375, 1376, 1377, 1378, 1379, 1380, 1381, 1382, 1383, 1384, 1385, 1386, 1387,
            1388, 1389, 1390, 1391, 1392, 1393, 1394, 1395, 1396, 1397, 1398, 1399, 1400, 1401, 1402, 1403, 1404, 1405,
            1406, 1407, 1408, 1409, 1410, 1411, 1412, 1413, 1414, 1415, 1416, 1417, 1418, 1419, 1420, 1421, 1422, 1423,
            1424, 1425, 1426, 1427, 1428, 1429, 1430, 1431, 1432, 1433, 1434, 1435, 1436, 1437, 1438, 1439, 1440, 1441,
            1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449, 1450, 1451, 1452, 1453, 1454, 1455, 1456, 1457, 1458, 1459,
            1460, 1461, 1462, 1463, 1464, 1465, 1466, 1467, 1468, 1469, 1470, 1471, 1472, 1473, 1474, 1475, 1476, 1477,
            1478, 1479, 1480, 1481, 1482, 1483, 1484, 1485, 1486, 1487, 1488, 1489, 1490, 1491, 1492, 1493, 1494, 1495,
            1496, 1497, 1498, 1499, 1500, 1501, 1502, 1503, 1504, 1505, 1506, 1507, 1508, 1509, 1510, 1511, 1512, 1513,
            1514, 1515, 1516, 1517, 1518, 1519, 1520, 1521, 1522, 1523, 1524, 1525, 1526, 1527, 1528, 1529, 1530, 1531,
            1532, 1533, 1534, 1535, 1536, 1537, 1538, 1539, 1540, 1541, 1542, 1543, 1544, 1545, 1546, 1547, 1548, 1549,
            1550, 1551, 1552, 1553, 1554, 1555, 1556, 1557, 1558, 1559, 1560, 1561, 1562, 1563, 1564, 1565, 1566, 1567,
            1568, 1569, 1570, 1571, 1572, 1573, 1574, 1575, 1576, 1577, 1578, 1581, 1582, 1588,

            // DLC 2
            1592, 1604, 1606,
        };

        internal static readonly ushort[] Pouch_Ball_SWSH =
        {
            001, 002, 003, 004, 005, 006, 007, 008, 009, 010, 011, 012, 013, 014, 015, 016,
            492, 493, 494, 495, 496, 497, 498, 499, 500,
            576,
            851,
        };

        internal static readonly ushort[] Pouch_Battle_SWSH =
        {
            055, 056, 057, 058, 059, 060, 061, 062, 063, 1580,
        };

        internal static readonly ushort[] Pouch_Items_SWSH = ArrayUtil.ConcatAll(Pouch_Regular_SWSH, Pouch_Ball_SWSH, Pouch_Battle_SWSH);

        internal static readonly ushort[] Pouch_Key_SWSH =
        {
            078,
            628, 629, 631, 632, 638,
            703,
            847,
            943, 944, 945, 946,
            1074, 1075, 1076, 1077, 1080, 1081, 1100, 1255, 1266, 1267,
            1269, 1270, 1271, 1278, 1583, 1584, 1585, 1586, 1587, 1589,

            // DLC 2
            1590, 1591, 1593, 1594, 1595, 1596, 1597, 1598, 1599, 1600, 1601, 1602, 1603, 1605, 1607,
        };

        internal static readonly ushort[] TM_SWSH =
        {
            328, 329, 330, 331, 332, 333, 334, 335, 336, 337,
            338, 339, 340, 341, 342, 343, 344, 345, 346, 347,
            348, 349, 350, 351, 352, 353, 354, 355, 356, 357,
            358, 359, 360, 361, 362, 363, 364, 365, 366, 367,
            368, 369, 370, 371, 372, 373, 374, 375, 376, 377,
            378, 379, 380, 381, 382, 383, 384, 385, 386, 387,
            388, 389, 390, 391, 392, 393, 394, 395, 396, 397,
            398, 399, 400, 401, 402, 403, 404, 405, 406, 407,
            408, 409, 410, 411, 412, 413, 414, 415, 416, 417,
            418, 419, 618, 619, 620, 690, 691, 692, 693, // TM99
            1230, // TM00
        };

        internal static readonly ushort[] TR_SWSH =
        {
            1130, 1131, 1132, 1133, 1134, 1135, 1136, 1137, 1138, 1139,
            1140, 1141, 1142, 1143, 1144, 1145, 1146, 1147, 1148, 1149,
            1150, 1151, 1152, 1153, 1154, 1155, 1156, 1157, 1158, 1159,
            1160, 1161, 1162, 1163, 1164, 1165, 1166, 1167, 1168, 1169,
            1170, 1171, 1172, 1173, 1174, 1175, 1176, 1177, 1178, 1179,
            1180, 1181, 1182, 1183, 1184, 1185, 1186, 1187, 1188, 1189,
            1190, 1191, 1192, 1193, 1194, 1195, 1196, 1197, 1198, 1199,
            1200, 1201, 1202, 1203, 1204, 1205, 1206, 1207, 1208, 1209,
            1210, 1211, 1212, 1213, 1214, 1215, 1216, 1217, 1218, 1219,
            1220, 1221, 1222, 1223, 1224, 1225, 1226, 1227, 1228, 1229,
        };

        internal static readonly ushort[] Pouch_TMHM_SWSH = ArrayUtil.ConcatAll(TM_SWSH, TR_SWSH);

        internal static readonly ushort[] Pouch_Medicine_SWSH =
        {
            017, 018, 019, 020, 021, 022, 023, 024, 025, 026,
            027, 028, 029, 030, 031, 032, 033, 034, 035, 036,
            037, 038, 039, 040, 041, 042, 043, 054,
            134,
            504, 591,
            708, 709,
            852, 903,
            1579,
        };

        internal static readonly ushort[] Pouch_Berries_SWSH =
        {
            149, 150, 151, 152, 153, 154, 155, 156, 157, 158,
            159, 160, 161, 162, 163, 169, 170, 171, 172, 173,
            174, 184, 185, 186, 187, 188, 189, 190, 191, 192,
            193, 194, 195, 196, 197, 198, 199, 200, 201, 202,
            203, 204, 205, 206, 207, 208, 209, 210, 211, 212,
            686, 687, 688,
        };

        internal static readonly ushort[] Pouch_Ingredients_SWSH =
        {
            1084, 1085, 1086, 1087, 1088, 1089, 1090, 1091, 1092, 1093,
            1094, 1095, 1096, 1097, 1098, 1099, 1256, 1257, 1258, 1259,
            1260, 1261, 1262, 1263, 1264,
        };

        internal static readonly ushort[] Pouch_Treasure_SWSH =
        {
            086, 087, 088, 089, 090, 091, 092, 094, 106,
            571, 580, 581, 582, 583,
            795, 796,
            1105, 1106, 1107, 1108,
        };

        internal static readonly ushort[] HeldItems_SWSH = ArrayUtil.ConcatAll(Pouch_Items_SWSH, Pouch_Berries_SWSH, Pouch_Medicine_SWSH, TR_SWSH, Pouch_Treasure_SWSH, Pouch_Ingredients_SWSH);

        internal static readonly int[] Tutors_SWSH_1 =
        {
            805, 807, 812, 804,
            803, 813, 811, 810,
            815, 814, 797, 806,
            800, 809, 799, 808,
            798, 802,
        };

        internal static readonly HashSet<int> GalarOriginForms = new()
        {
            (int)Species.Meowth,
            (int)Species.Ponyta,
            (int)Species.Rapidash,
            (int)Species.Slowpoke,
            (int)Species.Farfetchd,
            (int)Species.MrMime,
            (int)Species.Corsola,
            (int)Species.Zigzagoon,
            (int)Species.Linoone,
            (int)Species.Yamask,
            (int)Species.Darumaka,
            (int)Species.Darmanitan,
            (int)Species.Stunfisk,
        };

        internal static readonly HashSet<int> GalarVariantFormEvolutions = new()
        {
            (int)Species.MrMime,
            (int)Species.Weezing,
        };

        internal static readonly IReadOnlyDictionary<int, int> GalarForm0Evolutions = new Dictionary<int, int>
        {
            {(int)Species.Perrserker, 2},
            {(int)Species.Obstagoon, 1},
            {(int)Species.MrRime, 1},
            {(int)Species.Sirfetchd, 2},
            {(int)Species.Runerigus, 1},
            {(int)Species.Cursola, 1},
        };

        internal static readonly HashSet<int> ValidMet_SWSH = new()
        {
                           006, 008,
                 012, 014, 016, 018,
            020, 022, 024,      028,
            030, 032, 034, 036,
            040,      044, 046, 048,
            052, 054, 056, 058,
            060,      064, 066, 068,
            070, 072,      076, 078,
            080,      084, 086, 088,
            090, 092, 094, 096, 098,
                 102, 104, 106, 108,
            110, 112, 114, 116, 118,
            120, 122, 124, 126, 128,
            130, 132, 134, 136, 138,
            140, 142, 144, 146, 148,
            150, 152, 154, 156, 158,
            160,      164, 166, 168,
            170, 172, 174, 176, 178,
            180, 182, 184, 186, 188,
            190, 192, 194, 196, 198,
            200,

            202, 204, 206, 208, 210,
            212, 214, 216, 218, 220,
            222, 224, 226, 228, 230,
            232, 234, 236, 238, 240,
            242, 244, 246,
        };

        public static readonly int[] TMHM_SWSH =
        {
            // TM
            005, 025, 006, 007, 008, 009, 019, 042, 063, 416,
            345, 076, 669, 083, 086, 091, 103, 113, 115, 219,
            120, 156, 157, 168, 173, 182, 184, 196, 202, 204,
            211, 213, 201, 240, 241, 258, 250, 251, 261, 263,
            129, 270, 279, 280, 286, 291, 311, 313, 317, 328,
            331, 333, 340, 341, 350, 362, 369, 371, 372, 374,
            384, 385, 683, 409, 419, 421, 422, 423, 424, 427,
            433, 472, 478, 440, 474, 490, 496, 506, 512, 514,
            521, 523, 527, 534, 541, 555, 566, 577, 580, 581,
            604, 678, 595, 598, 206, 403, 684, 693, 707, 784,

            // TR
            014, 034, 053, 056, 057, 058, 059, 067, 085, 087,
            089, 094, 097, 116, 118, 126, 127, 133, 141, 161,
            164, 179, 188, 191, 200, 473, 203, 214, 224, 226,
            227, 231, 242, 247, 248, 253, 257, 269, 271, 276,
            285, 299, 304, 315, 322, 330, 334, 337, 339, 347,
            348, 349, 360, 370, 390, 394, 396, 398, 399, 402,
            404, 405, 406, 408, 411, 412, 413, 414, 417, 428,
            430, 437, 438, 441, 442, 444, 446, 447, 482, 484,
            486, 492, 500, 502, 503, 526, 528, 529, 535, 542,
            583, 599, 605, 663, 667, 675, 676, 706, 710, 776,
        };

        internal static readonly byte[] MovePP_SWSH =
        {
            00,
            35, 25, 10, 15, 20, 20, 15, 15, 15, 35, 30, 05, 10, 20, 30, 35, 35, 20, 15, 20, 20, 25, 20, 30, 05, 10, 15, 15, 15, 25, 20, 05, 35, 15, 20, 20, 10, 15, 30, 35, 20, 20, 30, 25, 40, 20, 15, 20, 20, 20,
            30, 25, 15, 30, 25, 05, 15, 10, 05, 20, 20, 20, 05, 35, 20, 20, 20, 20, 20, 15, 25, 15, 10, 20, 25, 10, 35, 30, 15, 10, 40, 10, 15, 30, 15, 20, 10, 15, 10, 05, 10, 10, 25, 10, 20, 40, 30, 30, 20, 20,
            15, 10, 40, 15, 10, 30, 10, 20, 10, 40, 40, 20, 30, 30, 20, 30, 10, 10, 20, 05, 10, 30, 20, 20, 20, 05, 15, 15, 20, 10, 15, 35, 20, 15, 10, 10, 30, 15, 40, 20, 10, 10, 05, 10, 30, 10, 15, 20, 15, 40,
            20, 10, 05, 15, 10, 10, 10, 15, 30, 30, 10, 10, 20, 10, 01, 01, 10, 25, 10, 05, 15, 25, 15, 10, 15, 30, 05, 40, 15, 10, 25, 10, 30, 10, 20, 10, 10, 10, 10, 10, 20, 05, 40, 05, 05, 15, 05, 10, 05, 10,
            10, 10, 10, 20, 20, 40, 15, 10, 20, 20, 25, 05, 15, 10, 05, 20, 15, 20, 25, 20, 05, 30, 05, 10, 20, 40, 05, 20, 40, 20, 15, 35, 10, 05, 05, 05, 15, 05, 20, 05, 05, 15, 20, 10, 05, 05, 15, 10, 15, 15,
            10, 10, 10, 20, 10, 10, 10, 10, 15, 15, 15, 10, 20, 20, 10, 20, 20, 20, 20, 20, 10, 10, 10, 20, 20, 05, 15, 10, 10, 15, 10, 20, 05, 05, 10, 10, 20, 05, 10, 20, 10, 20, 20, 20, 05, 05, 15, 20, 10, 15,
            20, 15, 10, 10, 15, 10, 05, 05, 10, 15, 10, 05, 20, 25, 05, 40, 15, 05, 40, 15, 20, 20, 05, 15, 20, 20, 15, 15, 05, 10, 30, 20, 30, 15, 05, 40, 15, 05, 20, 05, 15, 25, 25, 15, 20, 15, 20, 15, 20, 10,
            20, 20, 05, 05, 10, 05, 40, 10, 10, 05, 10, 10, 15, 10, 20, 15, 30, 10, 20, 05, 10, 10, 15, 10, 10, 05, 15, 05, 10, 10, 30, 20, 20, 10, 10, 05, 05, 10, 05, 20, 10, 20, 10, 15, 10, 20, 20, 20, 15, 15,
            10, 15, 15, 15, 10, 10, 10, 20, 10, 30, 05, 10, 15, 10, 10, 05, 20, 30, 10, 30, 15, 15, 15, 15, 30, 10, 20, 15, 10, 10, 20, 15, 05, 05, 15, 15, 05, 10, 05, 20, 05, 15, 20, 05, 20, 20, 20, 20, 10, 20,
            10, 15, 20, 15, 10, 10, 05, 10, 05, 05, 10, 05, 05, 10, 05, 05, 05, 15, 10, 10, 10, 10, 10, 10, 15, 20, 15, 10, 15, 10, 15, 10, 20, 10, 10, 10, 20, 20, 20, 20, 20, 15, 15, 15, 15, 15, 15, 20, 15, 10,
            15, 15, 15, 15, 10, 10, 10, 10, 10, 15, 15, 15, 15, 05, 05, 15, 05, 10, 10, 10, 20, 20, 20, 10, 10, 30, 15, 15, 10, 15, 25, 10, 15, 10, 10, 10, 20, 10, 10, 10, 10, 10, 15, 15, 05, 05, 10, 10, 10, 05,
            05, 10, 05, 05, 15, 10, 05, 05, 05, 10, 10, 10, 10, 20, 25, 10, 20, 30, 25, 20, 20, 15, 20, 15, 20, 20, 10, 10, 10, 10, 10, 20, 10, 30, 15, 10, 10, 10, 20, 20, 05, 05, 05, 20, 10, 10, 20, 15, 20, 20,
            10, 20, 30, 10, 10, 40, 40, 30, 20, 40, 20, 20, 10, 10, 10, 10, 05, 10, 10, 05, 05, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01, 01,
            01, 01, 01, 01, 01, 01, 01, 01, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 40, 15, 20, 30, 20, 15, 15, 20, 10, 15, 15, 10, 05, 10, 10, 20, 15, 10, 15, 15, 15, 05, 15, 20, 20, 01, 01, 01, 01, 01, 01,
            01, 01, 01, 05, 05, 10, 10, 10, 20, 10, 10, 10, 05, 05, 20, 10, 10, 10, 01, 05, 15, 05, 01, 01, 01, 01, 01, 01, 10, 15, 15, 20, 20, 20, 20, 15, 15, 10, 10, 05, 20, 05, 10, 05, 15, 10, 10, 05, 15, 20,
            10, 10, 15, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 05, 10, 15, 10, 15, 05, 05, 05, 10, 15, 40, 10, 10, 10, 15, 10, 10, 10, 10, 05, 05, 05, 10, 05, 20, 10,
            10, 05, 20, 20, 10, 10, 05, 05, 05, 40, 10, 20, 10, 10, 10, 10, 05, 05, 15, 05, 10, 10, 10, 05, 05, 05,
        };

        #region Unreleased Items
        internal static readonly bool[] ReleasedHeldItems_8 = GetPermitList(MaxItemID_8, HeldItems_SWSH, new ushort[]
        {
            298, // Flame Plate
            299, // Splash Plate
            300, // Zap Plate
            301, // Meadow Plate
            302, // Icicle Plate
            303, // Fist Plate
            304, // Toxic Plate
            305, // Earth Plate
            306, // Sky Plate
            307, // Mind Plate
            308, // Insect Plate
            309, // Stone Plate
            310, // Spooky Plate
            311, // Draco Plate
            312, // Dread Plate
            313, // Iron Plate
            // 644, // Pixie Plate

            1279, // ★And458 (Jangmo-o)
            1280, // ★And15 (Larvitar)
            1281, // ★And337 (Corviknight)
            1282, // ★And603 (Eiscue)
            1283, // ★And390 (Stonjourner)
            1284, // ★Sgr6879 (Copperajah)
            1285, // ★Sgr6859 (Centiskorch)
            1286, // ★Sgr6913 (Flapple/Appletun)
            1287, // ★Sgr7348 (Sandaconda)
            1288, // ★Sgr7121 (Duraludon)
            1289, // ★Sgr6746 (Pikachu)
            1290, // ★Sgr7194 (Eevee)
            1291, // ★Sgr7337
            1292, // ★Sgr7343
            1293, // ★Sgr6812
            1294, // ★Sgr7116
            1295, // ★Sgr7264
            1296, // ★Sgr7597
            1297, // ★Del7882
            1298, // ★Del7906
            1299, // ★Del7852
            1300, // ★Psc596
            1301, // ★Psc361
            1302, // ★Psc510
            1303, // ★Psc437
            1304, // ★Psc8773
            1305, // ★Lep1865
            1306, // ★Lep1829
            1307, // ★Boo5340
            1308, // ★Boo5506
            1309, // ★Boo5435
            1310, // ★Boo5602
            1311, // ★Boo5733
            1312, // ★Boo5235
            1313, // ★Boo5351
            1314, // ★Hya3748
            1315, // ★Hya3903
            1316, // ★Hya3418
            1317, // ★Hya3482
            1318, // ★Hya3845
            1319, // ★Eri1084
            1320, // ★Eri472
            1321, // ★Eri1666
            1322, // ★Eri897
            1323, // ★Eri1231
            1324, // ★Eri874
            1325, // ★Eri1298
            1326, // ★Eri1325
            1327, // ★Eri984
            1328, // ★Eri1464
            1329, // ★Eri1393
            1330, // ★Eri850
            1331, // ★Tau1409
            1332, // ★Tau1457
            1333, // ★Tau1165
            1334, // ★Tau1791
            1335, // ★Tau1910
            1336, // ★Tau1346
            1337, // ★Tau1373
            1338, // ★Tau1412
            1339, // ★CMa2491
            1340, // ★CMa2693
            1341, // ★CMa2294
            1342, // ★CMa2827
            1343, // ★CMa2282
            1344, // ★CMa2618
            1345, // ★CMa2657
            1346, // ★CMa2646
            1347, // ★UMa4905
            1348, // ★UMa4301
            1349, // ★UMa5191
            1350, // ★UMa5054
            1351, // ★UMa4295
            1352, // ★UMa4660
            1353, // ★UMa4554
            1354, // ★UMa4069
            1355, // ★UMa3569
            1356, // ★UMa3323
            1357, // ★UMa4033
            1358, // ★UMa4377
            1359, // ★UMa4375
            1360, // ★UMa4518
            1361, // ★UMa3594
            1362, // ★Vir5056
            1363, // ★Vir4825
            1364, // ★Vir4932
            1365, // ★Vir4540
            1366, // ★Vir4689
            1367, // ★Vir5338
            1368, // ★Vir4910
            1369, // ★Vir5315
            1370, // ★Vir5359
            1371, // ★Vir5409
            1372, // ★Vir5107
            1373, // ★Ari617
            1374, // ★Ari553
            1375, // ★Ari546
            1376, // ★Ari951
            1377, // ★Ori1713
            1378, // ★Ori2061
            1379, // ★Ori1790
            1380, // ★Ori1903
            1381, // ★Ori1948
            1382, // ★Ori2004
            1383, // ★Ori1852
            1384, // ★Ori1879
            1385, // ★Ori1899
            1386, // ★Ori1543
            1387, // ★Cas21
            1388, // ★Cas168
            1389, // ★Cas403
            1390, // ★Cas153
            1391, // ★Cas542
            1392, // ★Cas219
            1393, // ★Cas265
            1394, // ★Cnc3572
            1395, // ★Cnc3208
            1396, // ★Cnc3461
            1397, // ★Cnc3449
            1398, // ★Cnc3429
            1399, // ★Cnc3627
            1400, // ★Cnc3268
            1401, // ★Cnc3249
            1402, // ★Com4968
            1403, // ★Crv4757
            1404, // ★Crv4623
            1405, // ★Crv4662
            1406, // ★Crv4786
            1407, // ★Aur1708
            1408, // ★Aur2088
            1409, // ★Aur1605
            1410, // ★Aur2095
            1411, // ★Aur1577
            1412, // ★Aur1641
            1413, // ★Aur1612
            1414, // ★Pav7790
            1415, // ★Cet911
            1416, // ★Cet681
            1417, // ★Cet188
            1418, // ★Cet539
            1419, // ★Cet804
            1420, // ★Cep8974
            1421, // ★Cep8162
            1422, // ★Cep8238
            1423, // ★Cep8417
            1424, // ★Cen5267
            1425, // ★Cen5288
            1426, // ★Cen551
            1427, // ★Cen5459
            1428, // ★Cen5460
            1429, // ★CMi2943
            1430, // ★CMi2845
            1431, // ★Equ8131
            1432, // ★Vul7405
            1433, // ★UMi424
            1434, // ★UMi5563
            1435, // ★UMi5735
            1436, // ★UMi6789
            1437, // ★Crt4287
            1438, // ★Lyr7001
            1439, // ★Lyr7178
            1440, // ★Lyr7106
            1441, // ★Lyr7298
            1442, // ★Ara6585
            1443, // ★Sco6134
            1444, // ★Sco6527
            1445, // ★Sco6553
            1446, // ★Sco5953
            1447, // ★Sco5984
            1448, // ★Sco6508
            1449, // ★Sco6084
            1450, // ★Sco5944
            1451, // ★Sco6630
            1452, // ★Sco6027
            1453, // ★Sco6247
            1454, // ★Sco6252
            1455, // ★Sco5928
            1456, // ★Sco6241
            1457, // ★Sco6165
            1458, // ★Tri544
            1459, // ★Leo3982
            1460, // ★Leo4534
            1461, // ★Leo4357
            1462, // ★Leo4057
            1463, // ★Leo4359
            1464, // ★Leo4031
            1465, // ★Leo3852
            1466, // ★Leo3905
            1467, // ★Leo3773
            1468, // ★Gru8425
            1469, // ★Gru8636
            1470, // ★Gru8353
            1471, // ★Lib5685
            1472, // ★Lib5531
            1473, // ★Lib5787
            1474, // ★Lib5603
            1475, // ★Pup3165
            1476, // ★Pup3185
            1477, // ★Pup3045
            1478, // ★Cyg7924
            1479, // ★Cyg7417
            1480, // ★Cyg7796
            1481, // ★Cyg8301
            1482, // ★Cyg7949
            1483, // ★Cyg7528
            1484, // ★Oct7228
            1485, // ★Col1956
            1486, // ★Col2040
            1487, // ★Col2177
            1488, // ★Gem2990
            1489, // ★Gem2891
            1490, // ★Gem2421
            1491, // ★Gem2473
            1492, // ★Gem2216
            1493, // ★Gem2777
            1494, // ★Gem2650
            1495, // ★Gem2286
            1496, // ★Gem2484
            1497, // ★Gem2930
            1498, // ★Peg8775
            1499, // ★Peg8781
            1500, // ★Peg39
            1501, // ★Peg8308
            1502, // ★Peg8650
            1503, // ★Peg8634
            1504, // ★Peg8684
            1505, // ★Peg8450
            1506, // ★Peg8880
            1507, // ★Peg8905
            1508, // ★Oph6556
            1509, // ★Oph6378
            1510, // ★Oph6603
            1511, // ★Oph6149
            1512, // ★Oph6056
            1513, // ★Oph6075
            1514, // ★Ser5854
            1515, // ★Ser7141
            1516, // ★Ser5879
            1517, // ★Her6406
            1518, // ★Her6148
            1519, // ★Her6410
            1520, // ★Her6526
            1521, // ★Her6117
            1522, // ★Her6008
            1523, // ★Per936
            1524, // ★Per1017
            1525, // ★Per1131
            1526, // ★Per1228
            1527, // ★Per834
            1528, // ★Per941
            1529, // ★Phe99
            1530, // ★Phe338
            1531, // ★Vel3634
            1532, // ★Vel3485
            1533, // ★Vel3734
            1534, // ★Aqr8232
            1535, // ★Aqr8414
            1536, // ★Aqr8709
            1537, // ★Aqr8518
            1538, // ★Aqr7950
            1539, // ★Aqr8499
            1540, // ★Aqr8610
            1541, // ★Aqr8264
            1542, // ★Cru4853
            1543, // ★Cru4730
            1544, // ★Cru4763
            1545, // ★Cru4700
            1546, // ★Cru4656
            1547, // ★PsA8728
            1548, // ★TrA6217
            1549, // ★Cap7776
            1550, // ★Cap7754
            1551, // ★Cap8278
            1552, // ★Cap8322
            1553, // ★Cap7773
            1554, // ★Sge7479
            1555, // ★Car2326
            1556, // ★Car3685
            1557, // ★Car3307
            1558, // ★Car3699
            1559, // ★Dra5744
            1560, // ★Dra5291
            1561, // ★Dra6705
            1562, // ★Dra6536
            1563, // ★Dra7310
            1564, // ★Dra6688
            1565, // ★Dra4434
            1566, // ★Dra6370
            1567, // ★Dra7462
            1568, // ★Dra6396
            1569, // ★Dra6132
            1570, // ★Dra6636
            1571, // ★CVn4915
            1572, // ★CVn4785
            1573, // ★CVn4846
            1574, // ★Aql7595
            1575, // ★Aql7557
            1576, // ★Aql7525
            1577, // ★Aql7602
            1578, // ★Aql7235

            016, // Cherish Ball
            500, // Park Ball
        });
        #endregion

        /// <summary>
        /// Moves that are kill
        /// </summary>
        public static readonly HashSet<int> DummiedMoves_SWSH = new()
        {
            002, 003, 004, 013, 026, 027, 041, 049, 082, 096,
            099, 112, 117, 119, 121, 125, 128, 131, 132, 134,
            140, 145, 146, 148, 149, 159, 169, 171, 185, 193,
            216, 218, 222, 228, 237, 265, 274, 287, 289, 290,
            293, 300, 301, 302, 316, 318, 320, 324, 327, 346,
            357, 358, 363, 373, 376, 377, 378, 381, 382, 386,
            426, 429, 431, 443, 445, 456, 466, 477, 481, 485,
            498, 507, 516, 531, 537, 563, 569, 622, 623, 624,
            625, 626, 627, 628, 629, 630, 631, 632, 633, 634,
            635, 636, 637, 638, 639, 640, 641, 642, 643, 644,
            645, 646, 647, 648, 649, 650, 651, 652, 653, 654,
            655, 656, 657, 658, 671, 695, 696, 697, 698, 699,
            700, 701, 702, 703, 719, 723, 724, 725, 726, 727,
            728, 729, 730, 731, 732, 733, 734, 735, 736, 737,
            738, 739, 740, 741,
        };

        internal static readonly int[] TypeTutor8 =
        {
            (int)Move.GrassPledge,
            (int)Move.FirePledge,
            (int)Move.WaterPledge,
            (int)Move.FrenzyPlant,
            (int)Move.BlastBurn,
            (int)Move.HydroCannon,
            (int)Move.DracoMeteor,
            (int)Move.SteelBeam,
        };
    }
}
