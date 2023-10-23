# App
Aplikacja została zrealiowana w ASP .NET w C# przy użyciu biblioteki bootstrap do frontendu oraz EF-Core do zarządzania logiką bazy danych

## Cele projektu
- Stworzenie aplikacji pozwalającej na dodawanie wyników pomiarów w laboratorium
  + Dodawanie wielu wartości w różnych jednostkach
  + Eksportowanie wartości z danego pomiaru do pliku CSV
- Stworzenie bazy danych do zarządzania aplikacją
    + Stworzenie widoku na stronie pozwalającego na przyjemne przeglądanie danych z bazy danych
    + Dodanie prostego filtra daty

 ## Użyte technologie
 - ASP .NET
 - C#
 - Bootstrap
 - EF-Core SQLServer

## Rzeczy możliwe do poprawy
- Dodanie możliwości usunięcia rekordu przy dodawaniu
- Dodanie paginacji, w przypadku jeśli nasza baza danych zawierałaby wiele rekordów
- Dodanie ładniejszego interfejsu
- Udostępnienie aplikacji na publicznym serwerze

## Instrukcje uruchomienia
 1. Klikamy na plik .sln i odpalamy projekt  w Visual Studio
 2. `Narzędzia` -> `Menedżer pakietów NuGer` -> `Konsola menedżera`
 3. W konsoli wpisujemy `update-databse`
 4. `Ctrl + F5` -> Odpala aplikację na localhoscie
### Dodawanie migracji
W konsoli menedżera NuGet -> `add-migrarion [nazwa migracji] -OutputDir DB/Migrations`  
To stworzy nową migrację w odpowiednim folderze nie zaśmiecając nam projektu
### Stawianie bazy danych na nowo
1. Usuwamy bazę danych `drop-database`
2. Z folderu `DB/Migrations` usuwamy wszystkie migracje
3. `add-migration Initial -OutputDir DB/Migrations`
