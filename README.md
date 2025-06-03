## Features

- Display days of the week as selectable buttons.
- Show lessons with clickable buttons for the selected day.
- Open Zoom meeting links in the default browser upon clicking a lesson.
- Clean, easy-to-use interface using WPF.
- Responsive UI updates based on user input.
- Basic error handling for URL opening failures.

---
![image](https://github.com/user-attachments/assets/aa8c87e4-9868-4847-92fb-4d0da204a6e2)


## Technologies

- C# (.NET 8)
- WPF (Windows Presentation Foundation)
- `System.Diagnostics.Process` for opening URLs
- Visual Studio for development

---

## How It Works

1. User selects a day (Monday to Friday) from the UI buttons.
2. The app dynamically loads and displays all lessons scheduled for that day.
3. Clicking on a lesson button opens the associated Zoom meeting link in the system's default web browser.
4. If the link cannot be opened, a friendly error message is displayed.

---

## Getting Started

To run the application locally, follow these steps:

```bash
git clone https://github.com/yourusername/ScheduleApp.git
