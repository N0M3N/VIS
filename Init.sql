Insert into [dbo].[Stav]([Nazev]) values('Nova')
Insert into [dbo].[Stav]([Nazev]) values('Zapocata')
Insert into [dbo].[Stav]([Nazev]) values('Dokoncena')

Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Patrik', 'Kubicek', '+420123456789', 'patrik', 'patrik', 1, 1);
Insert into [dbo].[Uzivatel]([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) 
	values('Petr', 'Sramek', '+420987654321', 'petr', 'petr', 1, 1);

Insert into [dbo].[Zakazka]([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) 
	values('Domecek ze sirek', (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Sramek'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 1, 'Pod Skrtatkem 666, Spalena', 636784416000000000);

Insert into [dbo].[StavebniDenik]([Zakazka-Id], [Uzivatel-Id], [Datum], [Popis])
	values((SELECT [Id] FROM [dbo].[Zakazka] WHERE [Nazev] = 'Domecek ze sirek'), (SELECT [Id] FROM [dbo].[Uzivatel] WHERE [Prijmeni] = 'Kubicek'), 636784416000000000, 'POPIS ZAZNAMU');