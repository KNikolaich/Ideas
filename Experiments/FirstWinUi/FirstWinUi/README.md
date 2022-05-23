

# Тестовая задачка по WinUI3
## Однооконный простой браузер 

## Постановка задачи

- создать winui 3 приложение из шаблона
- запретить запуск нескольких копий приложения
- добавить на основное окно приложения webView и поле ввода для адреса, кнопку перейти
- по enter открывать введенный адрес в webview
- если введен некорректный адрес - вывести сообщение о неправильном адресе
- отступы между элементами и окном, растягивание окна - приложение должно иметь презентабельный вид 


## Tech

Dillinger uses a number of open source projects to work properly:
 - [Создание простого приложения](https://docs.microsoft.com/ru-ru/windows/apps/winui/winui3/create-your-first-winui3-app)
 - [Однократный создание экземпляров](https://docs.microsoft.com/ru-RU/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/applifecycle#single-instancing-in-main-or-wwinmain)
- 


## File Structure
```
.
├── FirstWinUi/ - WinUI 3 Desktop app
│ ├── Activation/ - app activation handlers
│ ├── Behaviors/ - UI controls behaviors
│ ├── Contracts/ - class interfaces
│ ├── Helpers/ - static helper classes
│ ├── Services/ - services implementations
│ │ ├── ActivationService.cs - app activation and initialization
│ │ ├── NavigationService.cs - navigate between pages
│ │ └──  ...
│ ├── Strings/en-us/Resources.resw - localized string resources
│ ├── Styles/ - custom style definitions
│ ├── ViewModels/ - properties and commands consumed in the views
│ ├── Views/ - UI pages
│ │ ├── ShellPage.xaml - main app page with navigation frame (only for SplitView and MenuBar)
│ │ └── ...
│ └── App.xaml - app definition and lifecycle events
│ └── Package.appxmanifest - app properties and declarations
├── FirstWinUi.Core/ - core project (.NET Standard)
│ ├── Contracts/ - class interfaces
│ ├── Helpers/ - static helper classes
│ ├── Models/ - business models
│ └── Services/ - services implementations
└── README.md
```

### Design pattern
This app uses MVVM Toolkit, for more information see https://aka.ms/mvvmtoolkit.

### Project type
This app is a blank project, for more information see [blank docs](https://github.com/microsoft/TemplateStudio/blob/main/docs/WinUI/projectTypes/blank.md).

## Publish / Distribute
For projects with MSIX packaging enabled, right-click on the application project and select `Package and Publish -> Create App Packages...` to create an MSIX package.

## Additional Documentation

- [TS WinUI 3 docs](https://github.com/microsoft/TemplateStudio/tree/main/docs/WinUI)
- [WinUI 3 docs](https://docs.microsoft.com/windows/apps/winui/winui3/)
- [WinUI 3 GitHub repo](https://github.com/microsoft/microsoft-ui-xaml)
- [Windows App SDK GitHub repo](https://github.com/microsoft/WindowsAppSDK)
