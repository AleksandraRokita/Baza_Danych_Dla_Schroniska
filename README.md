# Dokumentacja

### Założenia niefunkcjonalne
- **Database:** SQL Server
- **BackEnd:** C#, ASP.NET Core
- **FrontEnd:** CSS, HTML

### Modele
#### 1. Adopcja
Model odpowiadający za informacje o adopcjach zwierząt.
- **Pola:**
  - IdAdopcji: Unikalny identyfikator adopcji.
  - IdZwierzecia: Identyfikator zwierzęcia podlegającego adopcji.
  - IdUzytkownika: Identyfikator użytkownika adoptującego zwierzę.
  - IdPracownika: Identyfikator pracownika obsługującego adopcję.
  - StatusAdopcji: Status adopcji (np. oczekująca, zakończona).
  - DataRozpoczeciaAdopcji: Data rozpoczęcia procesu adopcji.
  - DataZakonczeniaAdopcji: Data zakończenia procesu adopcji.

#### 2. Lokacja
Model przechowujący informacje o lokalizacjach zwierząt w schronisku.
- **Pola:**
  - IdLokacji: Unikalny identyfikator lokacji.
  - Lokacja1: Opis lokacji (np. nazwa pomieszczenia lub strefy).

#### 3. Pracownik
Model reprezentujący pracowników schroniska.
- **Pola:**
  - IdPracownika: Unikalny identyfikator pracownika.
  - Imie: Imię pracownika.
  - Nazwisko: Nazwisko pracownika.

#### 4. Użytkownik
Model dla użytkowników adoptujących zwierzęta.
- **Pola:**
  - IdUzytkownika: Unikalny identyfikator użytkownika.
  - Imie: Imię użytkownika.
  - Nazwisko: Nazwisko użytkownika.

#### 5. Zwierze
Model opisujący zwierzęta znajdujące się w schronisku.
- **Pola:**
  - IdZwierzecia: Unikalny identyfikator zwierzęcia.
  - Gatunek: Gatunek zwierzęcia (np. pies, kot).
  - Imie: Imię zwierzęcia.
  - Rasa: Rasa zwierzęcia.
  - Wiek: Wiek zwierzęcia.
  - Waga: Waga zwierzęcia.
  - IdLokacji: Identyfikator lokacji, w której znajduje się zwierzę.

### Kontrolery
#### 1. HomeController
Kontroler stworzony do obsługi stron domyślnych, takich jak strona główna, polityka prywatności oraz obsługa błędów.

- **Metody:**
  - **Index():** Renderuje stronę główną.
  - **Privacy():** Renderuje stronę z polityką prywatności.
  - **Error():** Obsługuje błędy aplikacji.

#### 2. AdopcjasController
Obsługuje zarządzanie adopcjami zwierząt.
- **Endpointy:**
  - GET `/Adopcjas`: Wyświetla listę wszystkich adopcji.
  - GET `/Adopcjas/Details/{id}`: Wyświetla szczegóły adopcji.
  - POST `/Adopcjas/Create`: Tworzy nową adopcję.
  - POST `/Adopcjas/Edit/{id}`: Edytuje istniejącą adopcję.
  - POST `/Adopcjas/Delete/{id}`: Usuwa adopcję.

#### 3. LokacjaController
Obsługuje zarządzanie lokalizacjami w schronisku.
- **Endpointy:**
  - GET `/Lokacja`: Wyświetla listę lokalizacji.
  - GET `/Lokacja/Details/{id}`: Wyświetla szczegóły lokacji.
  - POST `/Lokacja/Create`: Tworzy nową lokację.
  - POST `/Lokacja/Edit/{id}`: Edytuje istniejącą lokację.
  - POST `/Lokacja/Delete/{id}`: Usuwa lokację.

#### 4. PracowniksController
Obsługuje zarządzanie pracownikami schroniska.
- **Endpointy:**
  - GET `/Pracowniks`: Wyświetla listę pracowników.
  - GET `/Pracowniks/Details/{id}`: Wyświetla szczegóły pracownika.
  - POST `/Pracowniks/Create`: Tworzy nowego pracownika.
  - POST `/Pracowniks/Edit/{id}`: Edytuje dane pracownika.
  - POST `/Pracowniks/Delete/{id}`: Usuwa pracownika.

#### 5. UzytkowniksController
Obsługuje zarządzanie użytkownikami adoptującymi zwierzęta.
- **Endpointy:**
  - GET `/Uzytkowniks`: Wyświetla listę użytkowników.
  - GET `/Uzytkowniks/Details/{id}`: Wyświetla szczegóły użytkownika.
  - POST `/Uzytkowniks/Create`: Tworzy nowego użytkownika.
  - POST `/Uzytkowniks/Edit/{id}`: Edytuje dane użytkownika.
  - POST `/Uzytkowniks/Delete/{id}`: Usuwa użytkownika.

#### 6. ZwierzeController
Obsługuje zarządzanie zwierzętami w schronisku.
- **Endpointy:**
  - GET `/Zwierze`: Wyświetla listę zwierząt z filtrowaniem.
  - GET `/Zwierze/Details/{id}`: Wyświetla szczegóły zwierzęcia.
  - POST `/Zwierze/Create`: Dodaje nowe zwierzę.
  - POST `/Zwierze/Edit/{id}`: Edytuje dane zwierzęcia.
  - POST `/Zwierze/Delete/{id}`: Usuwa zwierzę.

### Role
- **Admin:** Administrator systemu z pełnym dostępem do wszystkich funkcji aplikacji.

### Funkcjonalności aplikacji
1. **Zarządzanie adopcjami:**
   - Dodawanie, edycja, usuwanie adopcji.
   - Wyświetlanie listy i szczegółów adopcji.

2. **Zarządzanie lokalizacjami:**
   - Dodawanie, edycja, usuwanie lokalizacji.
   - Wyświetlanie listy i szczegółów lokalizacji.

3. **Zarządzanie pracownikami:**
   - Dodawanie, edycja, usuwanie pracowników.
   - Wyświetlanie listy i szczegółów pracowników.

4. **Zarządzanie użytkownikami:**
   - Dodawanie, edycja, usuwanie użytkowników.
   - Wyświetlanie listy i szczegółów użytkowników.

5. **Zarządzanie zwierzętami:**
   - Dodawanie, edycja, usuwanie zwierząt.
   - Wyświetlanie listy i szczegółów zwierząt.
   - Filtrowanie zwierząt po różnych kryteriach.

6. **Strona główna:**
   - Wyświetlanie strony głównej, polityki prywatności i obsługi błędów.

### Procedura: AktualizujStatusAdopcji
Procedura składowana aktualizująca status adopcji w tabeli `Adopcja`:
```sql
UPDATE [dbo].[Adopcja]
SET status_adopcji =
    CASE
        WHEN data_zakonczenia_adopcji IS NOT NULL THEN 'Zakończona'
        ELSE 'Rozpoczęta'
    END;
```
- Jeśli `data_zakonczenia_adopcji` nie jest NULL, status ustawiany jest na "Zakończona".
- W przeciwnym wypadku na "Rozpoczęta".

### Repozytorium
[Link do repozytorium](https://github.com/AleksandraRokita/Baza_Danych_Dla_Schroniska)
