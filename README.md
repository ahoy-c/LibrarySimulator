# LibrarySimulator

Library simulator. Supports creating users, borrowing and returning books. Features different access levels: regular user and administrator. Administrators can add and remove books. Books can now be created conveniently using the **BookBuilder**, and the program startup is handled via **StartProgram**.

## Program Startup

- `StartProgram prog = new();`  
  Creates and runs the program. Main logic is now inside `StartProgram`, keeping `Main` minimal.

## Public API (for regular users)

### Properties
- `string Title { get; }` — book title  
- `int Id { get; }` — book identifier  

### Book (main methods)
- `static void ListAllLibraryBooks()`  
  Displays all books in the library (available and borrowed).

- `void ShowInformationAboutBook()`  
  Displays detailed information about a specific book.

- `static void RemoveBook(int id)`  
  Removes a book from the library by its ID.

- `void TakeBook()`  
  Marks the book as borrowed (changes its availability status).

- `static bool IsId(int id)`  
  Checks if a book with the given ID exists.

- `static bool IsPresent(Book book)`  
  Checks if a book is currently available in the library.

- `static Book GetBook(int id)`  
  Returns the `Book` object by ID (throws an exception if not found).

### ElectronicBook and AudioBook
- Inherit from `Book` and have the same public properties and methods.  
- Override creation and information display messages (no new public properties).

### BookBuilder
- Fluent API for creating books:
```csharp
var book = new BookBuilder()
    .SetTitle("Example Title")
    .SetAuthor("Author Name")
    .SetPublicationYear(2025)
    .Build(); // or BuildElectronicBook("PDF"), BuildAudioBook("120")
```
### User (main methods)
- `void ShowBooks()`  
  Shows books currently borrowed by the user.

- `void TryTakeBook()`  
  Interactive attempt to borrow a book (asks for ID).

- `void TryReturnBook()`  
  Interactive attempt to return a book (asks for ID).

- `StatusUser Status { get; }` — user role (regular or administrator).


## Notes
- The README lists only the public properties and methods relevant to users. 
- No comments yet
