namespace SokoEqCalculator.controls;

public class ThemedImageButton : ImageButton
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ThemedImageButton), propertyChanged: OnImageSourceChanged);

    private static void OnImageSourceChanged(BindableObject bindable, object _, object newValue)
    {
        var self = (ThemedImageButton)bindable;
        ArgumentNullException.ThrowIfNull(self);
        self.OnThemeChanged(Application.Current.RequestedTheme);
    }

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public ThemedImageButton() : base()
    {
        Application.Current.RequestedThemeChanged += (_, e) => OnThemeChanged(e.RequestedTheme);
    }

    private void OnThemeChanged(AppTheme newTheme)
    {
        if (ImageSource == default)
        {
            return;
        }

        var postFix = newTheme is AppTheme.Light ? "_black" : "_white";
        if (!ImageSource.EndsWith(".png"))
        {
            postFix = $"{postFix}.png";
        }
        Source = $"{ImageSource}{postFix}";
    }
}