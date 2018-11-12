Insert into [dbo].[Stav]([Nazev]) values('Nova')
Insert into [dbo].[Stav]([Nazev]) values('Zapocata')
Insert into [dbo].[Stav]([Nazev]) values('Dokoncena')

Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Patrik', 'Kubicek', '+420123456789', 'patrik', 'patrik', 1, 1);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Petr', 'Sramek', '+420987654321', 'petr', 'petr', 1, 1);

Insert into [dbo].[Zakazka]([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) 
	values('Domeckek ze sirek', 2, 1, 1, 'Pod Skrtatkem 666, Spalena', CONVERT(datetime, '2019-11-24'))