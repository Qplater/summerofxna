_--Out of Date (lásd az SVN beszélgetést a groups oldalon)--_

#Segédlet a Tortoise SVN használatához.

# Tortoise SVN röviden #

A Tortoise SVN egy kliens program szerverek és repository-k eléréséhez. A repository fogalom egy helyet jelöl, ahol egy adott szoftvert tárolsz.


# Beszerzés és telepítés #

A programot a következő oldalról töltheted le: http://tortoisesvn.net/downloads. Válaszd ki a gépednek megfelelő verziót, töltsd le és telepítsd. Ezzel az alkalmazás beépült a környezeti menübe.

# Csatlakozás a repository-hoz és kliens oldali forráskönyvtár létrehozás #

Mielőtt csatlakoznál a szerverhez hozz létre egy könyvtárat valahol a merevlemezeden, ahol a továbbiakban tárolni szeretnéd a szerverről letöltött forrást. A könyvtár neve teljesen mindegy. Ha ez meg van kattints rajta a jobb egér gombbal és válaszd ki a menüből az "SVN Checkout" opciót. Ekkor kapsz egy kis ablakot, ahol egyelőre egyedül az URL mező érdekes számunkra. Ide a következő linket kell beírni (a felhasznalo helyére természetesen a gmail címed @ előtti része kerüljön)

```
https://summerofxna.googlecode.com/svn/trunk/ summerofxna --username felhasznalo
```

Nem kell jelszó, mert a Google tudja ki része a projektnek és ki nem. Ezután OK-kal zárd be az ablakot, a kliens letölti a mappába a szerveren található állományokat.

# Kezelés #

A kliens rengeteg funkcióval rendelkezik, számunkra egyelőre csak kettő fontos, ez a forrást ért változások letöltése és az általunk módosított fájlok feltöltése. Előbbi az _Update_ névre hallgat és a következőképpen működik:
Mielőtt elkezdenél dolgozni a forráson vagy feltöltenéd a változtatásaidat érdemes elvégezni a frissítést. A frissítéshez lépj be a forrás gyökérkönyvtárába, amit létrehoztál és amin beállítottad a csatlakozást. Ezen belül egy könyvtárat találsz majd, ebben vannak a projekt fájlai. Kattints ezen a mappán jobb egérgombbal és válaszd az "Update" opciót. A kliens frissít minden állományt illetve hozzáadja az újakat.
Ha módosítottál a projekten fel kell töltened a szerverre különben a többiek azt nem fogják látni, ezt a műveletet _Commit_-nak nevezik. Válaszd ki a projekt mappáját kattints rajt jobb egérgombbal és válaszd a "Commit" opciót. Ekkor kapsz egy ablakot, amiben két mező van. Az elsőbe beírhatod, hogy mit módosítottál vagy mit adtál hozzá a projekthez, a másodikban pedig kiválaszthatod, hogy a módosított fájlok közül melyikeket szeretnéd feltölteni. Abban az esetben ha egy teszteléskor felmerült hibát javítottál érdemes a hiba leírásának címét kimásolni innen az oldalról és bemásolni a Commit leírásába. Egyéb esetben elég egy mondatban összefoglalni a változásokat.

A szerver eltárolja a az összes változatát a projektnek, tehát ha valami hibásat töltesz fel, akkor visszaállítható egy korábbi verzióra, de mindenesetre csak akkor commitolj, ha biztos, hogy nincs benne a fordítást akadályozó hiba.