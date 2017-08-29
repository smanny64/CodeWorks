import sqlite3 as lite
import sys


        
stateList = ('ALABAMA', 'ALASKA', 'ARIZONA', 'ARKANSAS', 'CALIFORNIA', 'COLORADO', 'CONNECTICUT', 'DELAWARE', 'FLORIDA', 'GEORGIA', 'HAWAII', 'IDAHO', 'ILLINOIS', 'INDIANA', 'IOWA', 'KANSAS',
'KENTUCKY', 'LOUISIANA', 'MAINE', 'MARYLAND', 'MASSACHUSETTS', 'MICHIGAN', 'MINNESOTA', 'MISSISSIPPI', 'MISSOURI', 'MONTANA', 'NEBRASKA', 'NEVADA', 'NEW HAMPSHIRE', 'NEW JERSEY', 'NEW MEXICO', 
'NEW YORK', 'NORTH CAROLINA', 'NORTH DAKOTA', 'OHIO', 'OKLAHOMA', 'OREGON', 'PENNSYLVANIA', 'RHODE ISLAND', 'SOUTH CAROLINA', 'SOUTH DAKOTA', 'TENNESSEE', 'TEXAS', 'UTAH',
 'VERMONT', 'VIRGINIA', 'WASHINGTON', 'WEST VIRGINIA', 'WISCONSIN', 'WYOMING')  

stateAbr = ('AL', 'AK', 'AZ', 'AR', 'CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL', 'IN', 'IA', 'KS', 'KY', 
'LA', 'MA', 'MD', 'ME', 'MI', 'MN', 'MS', 'MO', 'MT', 'NE', 'NV', 'NH', 'NJ', 'NM', 'NY', 'NC', 'ND', 'OH', 
'OK', 'OR', 'PA', 'RI', 'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY')

capitalList = ('MONTGOMERY','JUNEAU', 'PHOENIX', 'LITTLE ROCK', 'SACRAMENTO', 'DENVER', 'HARTFORD', 'DOVER', 'TALLAHASSEE', 'ATLANTA', 'HONOLULU', 'BOISE', 'SPRINGFIELD', 'INDIANAPOLIS', 'DES MOINES',
'TOPEKA', 'FRANKFORT', 'BATON ROUGE', 'AUGUSTA', 'ANNAPOLIS', 'BOSTON', 'LANSING', 'ST. PAUL', 'JACKSON', 'JEFFERSON CITY', 'HELENA', 'LINCOLN', 'CARSON CITY', 'CONCORD', 'TRENTON',
'SANTA FE', 'ALBANY', 'RALEIGH', 'BISMARCK', 'COLUMBUS', 'OKLAHOMA CITY', 'SALEM', 'HARRISBURG', 'PROVIDENCE', 'COLUMBIA', 'PIERRE', 'NASHVILLE', 'AUSTIN', 'SALT LAKE CITY', 'MONTPELIER',
'RICHMOND', 'OLYMPIA', 'CHARLESTON', 'MADISON', 'CHEYENNE')

nickNameList = ('Yellowhammer State', 'The Last Frontier', 'The Grand Canyon State', 'The Natural State', 'The Golden State', 'The Centennial State', 'The Constitution State', 'The First State',
'The Sunshine State', 'The Peach State', 'The Aloha State', 'The Gem State', 'Prairie State', 'The Hoosier State', 'The Hawkeye State', 'The Sunflower State', 'The Bluegrass State', 'The Pelican State',
'The Pine Tree State', 'The Old Line State', 'The Bay State', 'The Great Lakes State', 'The North Star State', 'The Magnolia State', 'The Show MeState', 'The Treasure State', 'The Cornhusker State',
'The Silver State', 'The Granite State', 'The Garden State', 'The Land of Enchantment', 'The Empire State', 'The Tar HeelState', 'The Peace Garden State', 'The Buckeye State', 'The Sooner State',
'The Beaver State', 'The Keystone State', 'The Ocean State', 'The Palmetto State', 'Mount Rushmore State', 'The Volunteer State', 'The Lone Star State', 'The Beehive State', 'The Green Mountain State',
'The Old Dominion State', 'The Evergreen State', 'The Mountain State', 'The Badger State', 'The Equality State')


states = (('22', 'AL', 'ALABAMA', 'MONTGOMERY', '1849', 'Yellowhammer State'), ('49', 'AK', 'ALASKA', 'JUNEAU', '1959', 'The Last Frontier'), ('48', 'AZ', 'ARIZONA', 'PHOENIX', '1912', 'The Grand Canyon State'), ('25', 'AR', 'ARKANSAS', 'LITTLE ROCK', '1836', 'The Natural State'),
('31', 'CA', 'CALIFORNIA', 'SACRAMENTO', '1850', 'The Golden State'), ('38', 'CO', 'COLORADO', 'DENVER', '1876', 'The Centennial State'), ('5', 'CT', 'CONNECTICUT', 'HARTFORD', '1788', 'The Constitution State'), ('1', 'DE', 'DELAWARE', 'DOVER', '1787', 'The First State'),
('27', 'FL', 'FLORIDA', 'TALLAHASSEE','1845', 'The Sunshine State'), ('4', 'GA', 'GEORGIA', 'ATLANTA', '1788', 'The Peach State'), ('50', 'HI', 'HAWAII', 'HONOLULU', '1959', 'The Aloha State'), ('43', 'ID', 'IDAHO', 'BOISE', '1890', 'The Gem State'),
('21', 'IL', 'ILLINOIS', 'SPRINGFIELD', '1818', 'Prairie State'), ('19', 'IN','INDIANA', 'INDIANAPOLIS', '1816', 'The Hoosier State'), ('29', 'IA', 'IOWA', 'DES MOINES', '1846', 'The Hawkeye State'), ('34', 'KS', 'KANSAS', 'TOPEKA', '1861', 'The Sunflower State'),
('15', 'KY', 'KENTUCKY', 'FRANKFORT', '1792', 'The Bluegrass State'), ('18', 'LA', 'LOUISIANA', 'BATON ROUGE', '1812', 'The Pelican State'), ('23', 'MA', 'MAINE', 'AUGUSTA', '1820', 'The Pine Tree State'), ('7', 'MD', 'MARYLAND', 'ANNAPOLIS', '1788','The Old Line State'),
('6', 'ME', 'MASSACHUSETTS', 'BOSTON', '1788', 'The Bay State'), ('26', 'MI', 'MICHIGAN', 'LANSING', '1837', 'The Great Lakes State'), ('32', 'MN', 'MINNESOTA', 'ST. PAUL', '1858', 'The North Star State'), ('20', 'MS', 'MISSISSIPPI', 'JACKSON', '1817', 'The Magnolia State'),
('24', 'MO', 'MISSOURI', 'JEFFERSON CITY', '1821', 'The Show Me State'), ('41', 'MT', 'MONTANA', 'HELENA', '1889', 'The Treasure State'), ('37', 'NE', 'NEBRASKA', 'LINCOLN', '1867', 'The Cornhusker State'), ('36', 'NV', 'NEVADA', 'CARSON CITY', '1864', 'The Silver State'),
('9', 'NH', 'NEW HAMPSHIRE', 'CONCORD', '1788', 'The Granite State'), ('3', 'NJ', 'NEW JERSEY', 'TRENTON', '1787', 'The Garden State'), ('47', 'NM', 'NEW MEXICO', 'SANTA FE', '1912', 'The Land of Enchantment'), ('11', 'NY', 'NEW YORK', 'ALBANY', '1788', 'The Empire State'),
('12', 'NC', 'NORTH CAROLINA', 'RALEIGH', '1789', 'The Tar Heel State'), ('39', 'ND', 'NORTH DAKOTA', 'BISMARCK', '1889', 'The Peace Garden State'), ('17', 'OH', 'OHIO', 'COLUMBUS', '1803', 'The Buckeye State'), ('46', 'OK', 'OKLAHOMA', 'OKLAHOMA CITY', '1907', 'The Sooner State'),
('33', 'OR', 'OREGON', 'SALEM', '1859', 'The Beaver State'), ('2', 'PA', 'PENNSYLVANIA', 'HARRISBURG', '1787', 'The Keystone State'), ('13', 'RI', 'RHODE ISLAND', 'PROVIDENCE', '1790', 'The Ocean State'), ('8', 'SC', 'SOUTH CAROLINA', 'COLUMBIA', '1788', 'The Palmetto State'),
('40', 'SD', 'SOUTH DAKOTA', 'PIERRE', '1889', 'Mount Rushmore State'), ('16', 'TN', 'TENNESSEE', 'NASHVILLE', '1796', 'The Volunteer State'), ('28', 'TX', 'TEXAS', 'AUSTIN', '1845', 'The Lone Star State'), ('45', 'UT', 'UTAH', 'SALT LAKE CITY', '1896', 'The Beehive State'),
('14', 'VT', 'VERMONT', 'MONTPELIER', '1791', 'The Green Mountain State'), ('10', 'VA', 'VIRGINIA', 'RICHMOND', '1788', 'The Old Dominion State'), ('42', 'WA', 'WASHINGTON', 'OLYMPIA', '1889', 'The Evergreen State'), ('35', 'WV', 'WEST VIRGINIA', 'CHARLESTON', '1863', 'The Mountain State'),
('30', 'WI', 'WISCONSIN', 'MADISON', '1848', 'The Badger State'), ('44', 'WY', 'WYOMING', 'CHEYENNE', '1890', 'The Equality State'))  

n = "22-1849*49-1959*48-1912*25-1836*31-1850*38-1876*5-1788*1-1787*27-1845*4-1788*50-1959*43-1890*21-1818*19-1816*29-1846*34-1861*15-1792*18-1812*23-1820*7-1788*6-1788*26-1837*32-1858*20-1817*24-1821*41-1889*37-1867*36-1864*9-1788*3-1787*47-1912*11-1788*12-1789*39-1889*17-1803*46-1907*33-1859*2-1787*13-1790*8-1788*40-1889*16-1796*28-1845*45-1896*14-1791*10-1788*42-1889*35-1863*30-1848*44-1890"

quarters = ((2003, 'ALABAMA', 'Spirit of Courage,Hellen Keller'), (2008, 'ALASKA', 'The Great Land'), (2008, 'ARIZONA', 'Grand Canyon State'), (2003, 'ARKANSAS', 'None'), (2005, 'CALIFORNIA','Yosemite Valley,John Muir'), (2006, 'COLORADO', 'Colorful Colorado'),
(1999, 'CONNECTICUT', 'The Charter Oak'), (1999, 'DELAWARE', 'The First State,Caeser Rodney'), (2004, 'FLORIDA', 'Gateway to Discovery'), (1999, 'GEORGIA', 'Wisdom Moderation Justice'), (2008, 'HAWAII', 'Ua Mau Ke Ea O Ka Aina I Ka Pono'), (2007, 'IDAHO', 'Esto Perpetua'),
(2003,'ILLINOIS', 'Land of Lincoln,21st State Century'), (2002, 'INDIANA', 'Crossroads of America'), (2004, 'IOWA', 'Foundation in Education,Grant wood'), (2005, 'KANSAS', 'None'), (2001, 'KENTUCKY', 'My old Kentucky Home'), (2002, 'LOUISIANA', 'Louisiana Purchase'),
(2003, 'MAINE', 'None'), (2000, 'MARYLAND', 'The Old Line State'), (2000, 'MASSACHUSETTS', 'The Bay State'), (2004, 'MICHIGAN', 'The Great Lakes State'), (2005, 'MINNESOTA', ' Land Of The 10,000 Lakes'), (2002, 'MISSISSIPPI', 'The Magnolia State'), (2003, 'MISSOURI', 'Corps Of Discovery'),
(2007, 'MONTANA', 'Big Sky Country'), (2006, 'NEBRASKA', 'Chimney Rock'), (2006, 'NEVADA', 'The Silver State'), (2000, 'NEW HAMPSHIRE', 'Live Free Or Die,Old Man Of The Mountain'), (1999, 'NEW JERSEY', 'Crossroads Of A Revolution'), (2008, 'NEW MEXICO', 'Land Of Enchantment'),
(2001, 'NEW YORK', 'Gateway To Freedom'), (2001,'NORTH CAROLINA', 'First Flight'), (2006, 'NORTH DAKOTA', 'None'), (2002, 'OHIO', 'Birthplace Of Aviation Pioneers'), (2008, 'OKLAHOMA', 'None'), (2005, 'OREGON', 'Crater Lake'), (1999, 'PENNSYLVANIA', 'Virtue Liberty Independence'),
(2001, 'RHODE ISLAND', 'The Ocean State'), (2000, 'SOUTH CAROLINA', 'The Palmetto State'), (2006, 'SOUTH DAKOTA', 'None'), (2002, 'TENNESSEE', 'Musical Heritage'), (2004, 'TEXAS', 'The Lone Star State'), (2007, 'UTAH', 'Crossroads Of The West'), (2001, 'VERMONT', 'Freedom Unity'),
(2000, 'VIRGINIA', 'Jamestown 1607-2007, Quadricentennial'), (2007, 'WASHINGTON', 'The Evergreen State'), (2005, 'WEST VIRGINIA', 'New River Gorge'), (2004, 'WISCONSIN', 'FORWARD'), (2007, 'WYOMING', 'The Equality State'))  


con = lite.connect("coins.db")

with con:
    cur = con.cursor()
    cur.execute("DROP TABLE IF EXISTS States")
    cur.execute("CREATE TABLE States(Id INT UNIQUE, PostalCode TEXT UNIQUE NOT NULL, StateName TEXT PRIMARY KEY UNIQUE NOT NULL, Capital TEXT UNIQUE NOT NULL, StateHoodYear INT NOT NULL, NickName TEXT NOT NULL)")
    cur.executemany("INSERT INTO States VALUES(?,?,?,?,?,?)", states)
    
    cur.execute("DROP TABLE IF EXISTS Quarters")
    cur.execute("CREATE TABLE Quarters(Id INTEGER PRIMARY KEY AUTOINCREMENT, IssueYear INT NOT NULL, StateName TEXT UNIQUE NOT NULL, Remarks TEXT DEFAULT 'None', isCollected BOOLEAN DEFAULT 0, FOREIGN KEY (StateName) REFERENCES States(StateName))")
    cur.executemany("INSERT INTO Quarters(IssueYear, StateName, Remarks)  VALUES(?,?,?)", quarters)
#con.row_factory = lite.Row