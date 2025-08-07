# UnoBaseFramework

A base framework for Uno Platform projects that provides common infrastructure, styling, and patterns for building cross-platform applications.

## Overview

UnoBaseFramework is designed to be used as a foundation for Uno Platform projects. It includes:
- Base classes for Pages, ViewModels, and Models
- Comprehensive styling system with predefined styles
- Service registration patterns using Uno.Extensions
- Navigation infrastructure
- MVUX/Reactive patterns support

## Features

### Base Classes
- **BasePage** - Base class for all pages
- **BaseViewModel** - Base class for ViewModels with MVVM support
- **BaseItemModel** - Base class for data models

### Styling System
Complete styling infrastructure including:
- **Colors.xaml** - Color palette and brushes
- **TextStyles.xaml** - Typography styles (Display, Headline, Title, Body, Label, Caption)
- **ButtonStyles.xaml** - Button variants (Primary, Secondary, Text, Icon, Danger)
- **ControlStyles.xaml** - Common control styles
- **BaseStyles.xaml** - Master resource dictionary

### Service Infrastructure
- **ServiceCollectionExtensions** - Host builder configuration
- **NavigationExtensions** - Navigation setup helpers

## Project Structure

```
UnoBaseFramework/
├── UnoClaude/                    # Submodule with documentation
├── src/UnoBaseFramework/
│   ├── Base/                     # Base classes
│   │   ├── BasePage.cs
│   │   ├── BaseViewModel.cs
│   │   └── BaseItemModel.cs
│   ├── Pages/                    # Example pages
│   │   ├── ShellPage.xaml
│   │   └── ShellPage.xaml.cs
│   ├── Services/                 # Service extensions
│   │   ├── ServiceCollectionExtensions.cs
│   │   └── NavigationExtensions.cs
│   └── Styles/                   # XAML styles
│       ├── BaseStyles.xaml
│       ├── Colors.xaml
│       ├── TextStyles.xaml
│       ├── ButtonStyles.xaml
│       └── ControlStyles.xaml
├── Directory.Build.props         # MSBuild properties
├── Directory.Packages.props      # Central package management
└── global.json                   # SDK configuration
```

## Usage

### 1. Add as Package Reference

Add UnoBaseFramework to your Uno Platform project:

```xml
<PackageReference Include="UnoBaseFramework" Version="1.0.0" />
```

### 2. Configure in App.xaml.cs

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs args)
{
    var builder = this.CreateBuilder(args)
        .Configure(host => host
            .ConfigureUnoBaseFramework()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddBaseViewModels()
                    .AddBaseServices()
                    .AddBaseRepositories();
            })
        );

    MainWindow = builder.Window;
}
```

### 3. Use Base Styles in App.xaml

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="ms-appx:///UnoBaseFramework/Styles/BaseStyles.xaml"/>
            <!-- Your app-specific styles -->
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 4. Create Pages with BasePage

```csharp
public sealed partial class MyPage : BasePage
{
    public MyPage()
    {
        this.InitializeComponent();
    }
}
```

### 5. Create ViewModels with BaseViewModel

```csharp
public partial class MyViewModel : BaseViewModel
{
    private readonly IMyService _myService;
    
    public MyViewModel(IMyService myService)
    {
        _myService = myService;
    }
    
    public IFeed<string> Data => Feed.Async(async ct => 
        await _myService.GetDataAsync(ct)
    );
}
```

### 6. Apply Styles in XAML

```xml
<TextBlock Style="{StaticResource HeadlineLargeTextStyle}" 
           Text="Welcome" />

<Button Style="{StaticResource PrimaryButtonStyle}"
        Content="Continue" />

<Border Style="{StaticResource CardBorderStyle}">
    <TextBlock Style="{StaticResource BodyMediumTextStyle}" 
               Text="Card content" />
</Border>
```

## Architecture Guidelines

### Page and Region System
Pages should be divided into regions for better modularity:

```xml
<Page x:Class="MyApp.Pages.MyPage">
    <Grid>
        <ContentControl uen:Region.Attached="true"
                       uen:Region.Name="Header"/>
        <ContentControl uen:Region.Attached="true"
                       uen:Region.Name="Content"/>
    </Grid>
</Page>
```

### MVUX Pattern
Use Uno.Extensions.Reactive for reactive programming:

```csharp
public IFeed<ImmutableList<Product>> Products => Feed.Async(async ct =>
    await _productService.GetProductsAsync(ct)
);

public IState<string> SearchText => State<string>.Value(this, () => string.Empty);
```

### Styling Requirements
- Every control must have an explicit style
- No inline styling allowed
- Use semantic color names
- Support theme variations

## Dependencies

- Uno.Sdk 5.4.10
- Uno.Extensions 5.0.24
- Uno.Toolkit 6.3.10
- CommunityToolkit.Mvvm 8.3.2

## Building

1. Ensure you have .NET 9 SDK installed
2. Clone the repository with submodules:
   ```bash
   git clone --recursive https://github.com/Codelisk/UnoBaseFramework.git
   ```
3. Build the project:
   ```bash
   dotnet build
   ```

## Documentation

Detailed documentation is available in the UnoClaude submodule under `.claude/docs/`.

## License

[Your License Here]

## Contributing

[Your Contributing Guidelines Here]