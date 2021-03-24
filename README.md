
# Grupa9-AtomicFitness
## Tema: Aplikacija za Fitness
## Članovi:
* Tarik Đogić 
* Ajla Višća 
* Dinija Seferović 

<p align="center">
<img src="https://user-images.githubusercontent.com/64585658/111088792-35575000-8529-11eb-9afe-ae09d0769559.jpg" width="550">
</p>

## Opis teme:
Tjelesna aktivnost prirodna je potreba čovjeka, nužna za očuvanje i unapređenje zdravlja. 
Stručnjaci preporučuju svakodnevno 60 ili više minuta umjerene do intenzivne tjelesne aktivnosti.
Čovjek današnjice radikalno je smanjio tjelesnu aktivnost, što neosporno utiče na zdravlje, a ova aplikacija može pomoći pružajući brz i jednostavan način da se poboljša tjelesna aktivnost. Cilj aplikacije je da pomogne svakom zainteresiranom da napravi bolju verziju sebe, bilo da je riječ o gubitku kilograma, dobijanju mišićne mase, povećanju tjelesne snage ili unapređenju kardiovaskularnog sistema. Aplikacija sadrži veliku bazu raznih vježbi, prilagođenih kako za početnike, tako i za iskusnije korisnike i svako može naći za sebe ono što najviše odgovara njegovim potrebama i sposobnostima. Pored velikog izbora vježbi, korisnik ima pristup i zdravim receptima, jer osnovu unapređenja zdravlja, pored  kvalitetno vođenog treninga, čini i raznovrsna, izbalansirana i zdrava ishrana.

## Funkcionalnosti:
##### Korisnik:
- mogućnost registracije čime se kreira profil u sistemu
- nakon uspješne registracije moguće je koristiti aplikaciju prijavom 
- mogućnost kreiranja fitness profila, što uključuje i njegovo popunjavanje podacima
- mogućnost promjene podataka vlastitog profila ili fitness profila
- pretraživanje vježbi pomoću filtera ili bez filtera
- pretraživanje recepata pomoću filtera ili bez filtera
- mogućnost generiranja programa na osnovu vlastitog profila
- mogućnost kreiranja vlastitog programa
- mogućnost slušanja muzike korištenjem nekog online servisa na trenutnom uređaju ili nekom vanjskom uređaju

##### Administrator:
- mogućnost nadgledanja, održavanja i ažuriranja sistema, što podrazumijeva:
    - mogućnost pregledanja svih registrovanih korisnika i svih njihovih podataka
    - mogućnost brisanja registrovanih korisnika
    - mogućnost dodavanja vježbi ili recepata
    - mogućnost promjene vježbi ili recepata
    - mogućnost brisanja vježbi ili recepata

## Detaljan opis funkcionalnosti:
### Mogućnost registracije čime se kreira profil u sistemu:
   
   Korisnik se mora registrirati da bi koristio aplikaciju. Pri registraciji moraju se popuniti slijedeći podaci: ime, prezime, email adresa i password.
   Postoji ograničenje na maksimalan broj karaktera za ime, prezime, email adresu i password. Za password imamo i ograničenje na minimalni broj karaktera. Također se vrši validacija email adrese. Ukoliko su uneseni podaci uredu,
   na email adresu se šalje verifikacioni kod kojeg korisnik treba da ukuca u aplikaciji da bi finalizirao svoju registraciju.
   
### Nakon uspješne registracije moguće je koristiti aplikaciju prijavom:

   Registrovani korisnik nakon uspješne registracije ima mogućnost prijave prilikom ponovnog korištenja aplikacije.
   
### Mogućnost kreiranja fitness profila, što uključuje i njegovo popunjavanje podacima:

   Nakon registracije korisnik može napraviti svoj fitness profil i mora ga popuniti svojim podacima i ciljevima. Kod ovog procesa registrovanom korisniku se nude opcije od kojih bira koje mu odgovaraju. 
    
### Pretraživanje vježbi pomoću filtera ili bez filtera
    
   Registrovani korisnik ima mogućnost da pretražuje vježbe iz biblioteke vježbi gdje su za svaku vježbu navedeni osnovni podaci i slika. Također ima mogućnost da 
   pretraživanje vrši pomoću filtriranja na osnovu podataka o vježbama.
    
### Pretraživanje recepata pomoću filtera ili bez filtera

   Registrovani korisnik ima mogućnost da pretražuje zdrave recepte iz biblioteke recepata. Također ima mogućnost da pretraživanje vrši pomoću filtriranja na osnovu 
   željenih glavnih sastojaka.
   
### Mogućnost generiranja programa na osnovu vlastitog profila

   Registrovani korisnik, ukoliko je popunio podatke za fitness profil, ima mogućnost da mu se generiše program na osnovu unesenih informacija. Ukoliko njegov profil nije
   popunjen, odbija se zahtjev generisanja programa već nudi mu se da prvo popuni profil. Može se više puta generisati ako korisnik želi drugačiji program koji mu je ponuđen,      ukoliko postoji više programa koji odgovaraju njegovim 
   podacima i ciljevima iz fitness profila.
   
### Mogućnost kreiranja vlastitog programa

   Registrovani korisnik ima mogućnost da kreira vlastiti program vježbi birajući vježbe iz biblioteke vježbi koje će njegov program sadržavati.
   
### Mogućnost slušanja muzike 

   Registrovani korisnik ima mogućnost slušanja muzike korištenjem nekog online servisa na trenutnom uređaju ili nekom vanjskom uređaju. Muzika može svirati u pozadini
   dok korisnik obavlja neke druge akcije na aplikaciji.
   
## Akteri:
- Korisnik
- Administrator
