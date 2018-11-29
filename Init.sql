Insert into [dbo].[Stav]([Nazev]) values('Nova')
Insert into [dbo].[Stav]([Nazev]) values('Zapocata')
Insert into [dbo].[Stav]([Nazev]) values('Dokoncena')

Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Patrik', 'Kubicek', '+420123456789', 'patrik', 'patrik', 1, 1);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Petr', 'Sramek', '+420987654321', 'petr', 'petr', 1, 1);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Antonin', 'Svetlik', '+420567894123', 'tonda', 'tonda', 1, 0);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Martin', 'Valek', '+42061234789', 'martin', 'martin', 0, 1);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Jaromir', 'Bruza', '+420756312498', 'jarda', 'jarda', 0, 1);
	
Insert into [dbo].[Zakazka]([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) 
	values('Drevostavba v centru', (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 1, 'Gorkého 3037/2, Ostrava, 70200', 636784416000000000);
Insert into [dbo].[Zakazka]([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) 
	values('Oprava historicke budovy', (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Svetlik'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 3, 'K Namesti 26, Brusperk, 73944', 636784416000000000);
Insert into [dbo].[Zakazka]([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) 
	values('Klub odpadliku', (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Valek'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), 1, 'Hrabova 39, Hrabova, 78901', 636784416000000000);

Insert into [dbo].[StavebniDenik]([Zakazka-Id], [Uzivatel-Id], [Datum], [Popis])
	values((SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Drevostavba v centru'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 636784416000000000, 'Zakladova deska');

Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Drevostavba v centru'), 123);
Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Valek'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Drevostavba v centru'), 112);
Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Oprava historicke budovy'), 230);
Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Oprava historicke budovy'), 250);
Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Klub odpadliku'), 230);
Insert into [dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba])
	values((SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Bruza'), (SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Klub odpadliku'), 220);

	
Insert into [dbo].[Dochazka]([Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod])
	values((SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Drevostavba v centru'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 636784416000000000, 636784650000000000, 636785067000000000);
Insert into [dbo].[Dochazka]([Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod])
	values((SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Drevostavba v centru'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 636785280000000000, 636785604000000000, 636786072000000000);
Insert into [dbo].[Dochazka]([Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod])
	values((SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Oprava historicke budovy'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), 636784416000000000, 636784650000000000, 636785067000000000);