    /*
        ==========================================
        🚨 APP.FORMULAS - TABLE OF CONTENTS 🚨
        ==========================================

        Naming Guidlines (all the ideas):

            Notes (our guidline is based on these, in order of priority): 
                - Adhere to any current standards (practiced in the industry)
                - To be extremely handy while coding (IntelliSense)
                    - Having to wrap names with single quotes is NOT
                - All while retaining a meaningful name
                - Pretty (examples of ugly)
                    - Underscores could be considered ugly
                    - But!!! they are the only special chacter to use
                    -       that won't require 'var MyVar'
                - Personal preference

            All the types of thigs that can be in App.Formulas

                1 - Named Expressions (named formulas) 
                    - fxExp_    ** favorite

                2 - UDF (be sure to them on in settings)
                    - fxFun_     ** favorite
                    
                3 - UDT (be sure to them on in settings)                 
                    - fxTyp_     ** favorite

                    Example of primitive types:
                    - (you don't need to do so - already defined)
                    Example of record:
                    - fxTyp_ABC_Record **maybe too much?
                    Example of table of ...
                    - fxTyp_ABC_Table                    

            I love ProperCasing (personal preference)

        ==========================================

        fxTyp_BaseTheme_Table
        fxTyp_BaseTheme
        fxTyp_BaseColorPalette
        fxGetThemeFromMode
        fxLightDarkMode
        fxTyp_ColorDefinition
        fxTyp_ColorDefinition_Table
        fxExtendedTheme (depends on the following being there too)
            fxGrays
            fxLightDarkMode
            fxGrays
    */

    //fxFun_NewFunction():AppUser = "";

    fxTyp_MyAppUser_Table:= Type(
        AppUser
    );

    //
    // This is a user-defined type. A collection
    // of another UDT
    //
    fxTyp_BaseTheme_Table:= Type(
        [fxTyp_BaseTheme]
    );

    //fxCollection_OfBaseThemes = []

    //
    // This is the type that has been defined by Microsoft for modern theming
    // We'll include this type into the fxExtendedThemeType (our new snazzy theme)
    // See: https://learn.microsoft.com/en-us/power-apps/maker/canvas-apps/controls/modern-controls/modern-theming
    //
    // Base means 'bulit-in'
    //
    fxTyp_BaseTheme := Type(
        {
            Font:Text, 
            Name:Text,
            Colors: fxTyp_ColorPalette
        }
    );

    fxTyp_ColorPalette := Type(  
        {          
            Darker10:Color,
            Darker20:Color,
            Darker30:Color,
            Darker40:Color,
            Darker50:Color,
            Darker60:Color,
            Darker70:Color,
            Lighter10:Color,
            Lighter20:Color,
            Lighter30:Color,
            Lighter40:Color,
            Lighter50:Color,
            Lighter60:Color,
            Lighter70:Color,
            Lighter80:Color,
            Primary:Color,
            PrimaryForeground:Color
        }
    );

    //
    // UDF Function to return a base theme based on if the user
    // is in light / dark mode
    //
    // Any string that starts with one of these two: 
    //  - 'L'
    //  - 'D'
    //
    fxGetThemeFromMode(ThemeMode:Text):fxTyp_BaseTheme = (
        If(
            Upper(Left(ThemeMode, 1)) = "L", 
            PowerAppsTheme, 
            App.Theme
        )
    );

    //
    // Named formulas / expression
    // Returns a record with two properties
    // 
    fxLightDarkMode = {
        Light: "Light", 
        Dark: "Dark"
    };

    //
    // 
    //
    fxTyp_ColorDefinition:= Type(
        {
            Value:Color, 
            Name:Text, 
            HexCode:Text, 
            OppositeColorName:Text
        }
    );

    fxTyp_ColorDefinition_Table:= Type(
        [fxTyp_ColorDefinition]
    );

    fxExtendedTheme = {
        //
        //
        //
        ThemeName:              "Blue Yellow Orange", // Should be unique among themes created by a particular theme author
        ThemeKey:               "BLUE-YELLOW-ORANGE", // Should be unique among themes created by a particular theme author
        ThemeUUID:              "5f6b7f1d-443e-4c09-8201-0b75d8d9fd65", // A GUID the author or the system will generate to ensure a unique value
        ThemeAuthor:            "Darren Neese (support@superpowerlabs.co)",
        //
        // Three base properties so we never have to reference `App.Theme.___`
        //
        BaseFont:               App.Theme.Font, 
        BaseName:               App.Theme.Name,
        BaseColors:             App.Theme.Colors,
        //
        // Fonts (modern fonts need 3 more points/pixels)
        //
        DefaultFontName:        Font.'Open Sans', 
        DefaultFontSizeClassic: 12,
        //
        // Properties having to deal with light/dark mode feature
        //
        ThemeType:              fxLightDarkMode.Light, 
        PairedThemeGUID:        "",
        //
        // Colors
        //
        Colors: {
            Primary: {
                Value:                  ColorValue("#0f6cbd"), 
                Name:                   "Primary", 
                HexCode:                "#0f6cbd", 
                OppositeColorName:      "PrimaryOpposite"
            },
            PrimaryOpposite: {
                Value:ColorValue("#ffffff"), 
                Name:"PrimaryOpposite", 
                HexCode:"#ffffff", 
                OppositeColorName:"Primary"
            },
            Secondary: {
                Value:ColorValue("#F27405"), 
                Name:"Secondary", 
                HexCode:"#F27405", 
                OppositeColorName:"SecondaryOpposite"
            },
            SecondaryOpposite: {
                Value:ColorValue("#000000"), 
                Name:"SecondaryOpposite", 
                HexCode:"#000000", 
                OppositeColorName:"Secondary"
            },
            Accent: {
                Value:ColorValue("#ffff00"), 
                Name:"Accent", 
                HexCode:"#ffff00", 
                OppositeColorName:"AccentOpposite"
            },
            AccentOpposite: {
                Value:ColorValue("#000000"), 
                Name:"AccentOpposite", 
                HexCode:"#000000", 
                OppositeColorName:"Accent"
            },
            Background: {
                Value:ColorValue("#EBF2F2"), 
                Name:"Background", 
                HexCode:"#EBF2F2", 
                OppositeColorName:"BackgroundOpposite"
            },
            BackgroundOpposite: {
                Value:ColorValue("#0a2e4a"),            // Primary's Darker50 Shade
                Name:"BackgroundOpposite", 
                HexCode:"#0a2e4a", 
                OppositeColorName:"Background"
            },
            Neutral: {
                Value:ColorValue("#b4d6faff"),          // Primary's Lighter60
                Name:"Neutral", 
                HexCode:"#b4d6faff", 
                OppositeColorName:"NeutralOpposite"
            },
            NeutralOpposite: {
                Value:ColorValue("#0a2e4a"),            // Primary's Darker50 Shade
                Name:"NeutralOpposite", 
                HexCode:"#0a2e4a", 
                OppositeColorName:"Neutral"
            },
            Menu: {
                Value:ColorValue("#b4d6faff"),          // Primary's Lighter60
                Name:"Menu", 
                HexCode:"#b4d6faff", 
                OppositeColorName:"MenuOpposite"
            },
            MenuOpposite: {
                Value:ColorValue("#0c3b5eff"),            // Primary's Darker40 Shade
                Name:"MenuOpposite", 
                HexCode:"#0c3b5eff", 
                OppositeColorName:"Menu"
            }

        },
        //
        // Grays
        //
        Grays:                  fxGrays
    };

    fxGrays = {
        AlmostWhite:            RGBA(250, 250, 250, 1), 
        AlmostBlack:            RGBA(5, 5, 5, 1),
        Medium:                 RGBA(128, 128, 128, 1), 
        //
        // Lighter shades of gray
        //
        Darker10:               RGBA(112, 112, 112, 1),
        Darker20:               RGBA(96, 96, 96, 1),
        Darker30:               RGBA(80, 80, 80, 1),
        Darker40:               RGBA(64, 64, 64, 1),
        Darker50:               RGBA(48, 48, 48, 1),
        Darker60:               RGBA(32, 32, 32, 1),
        Darker70:               RGBA(16, 16, 16, 1),
        Darker80:               RGBA(8, 8, 8, 1),
        //
        // Darker shades of gray
        //
        Lighter10:              RGBA(143, 143, 143, 1),
        Lighter20:              RGBA(159, 159, 159, 1),
        Lighter30:              RGBA(175, 175, 175, 1),
        Lighter40:              RGBA(191, 191, 191, 1),
        Lighter50:              RGBA(207, 207, 207, 1),
        Lighter60:              RGBA(223, 223, 223, 1),
        Lighter70:              RGBA(239, 239, 239, 1),
        Lighter80:              RGBA(247, 247, 247, 1)
    };
