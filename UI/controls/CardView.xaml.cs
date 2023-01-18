using SokoEqCalculator.Models;

namespace SokoEqCalculator.controls;

public partial class CardView : ContentView
{
    public static readonly BindableProperty CardModelProperty =
            BindableProperty.Create(nameof(CardModel), typeof(CardModel), typeof(CardView), defaultValue: null, propertyChanged: OnCardModelChange);
    private static void OnCardModelChange(BindableObject bindable, object _, object newValue)
    {
        var self = (CardView)bindable;
        ArgumentNullException.ThrowIfNull(self);
        self.UpdateCardProperties();
    }
    public CardModel CardModel
    {
        get => (CardModel)GetValue(CardModelProperty);
        set => SetValue(CardModelProperty, value);
    }

    public static readonly BindableProperty CardDeckColorProperty =
            BindableProperty.Create(nameof(CardDeckColor), typeof(CardDeckColors), typeof(CardView), defaultValue: CardDeckColors.Four);
    public CardDeckColors CardDeckColor
    {
        get => (CardDeckColors)GetValue(CardDeckColorProperty);
        set => SetValue(CardDeckColorProperty, value);
    }

    public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CardView), defaultValue: Colors.White);
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(CardView), defaultValue: null);
    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    public CardView()
    {
        InitializeComponent();
    }

    private void UpdateCardProperties()
    {
        if (CardModel is null)
        {
            TextColor = Colors.White;
            ImageSource = null;
            return;
        }

        var colors = App.Colors;
        var (colorObj, imgSource) = GetCardProperties(colors, CardDeckColor, CardModel.Suite);
        var color = colorObj as Color;
        ArgumentNullException.ThrowIfNull(color);

        TextColor = color;
        ImageSource = ImageSource.FromFile(imgSource);
    }

    private (object color, string imgSource) GetCardProperties(ResourceDictionary dict, CardDeckColors colorType, string suite) => (colorType, suite) switch
    {
        (CardDeckColors.Two, "s") => (dict["Spade"], "spade_2.png"),
        (CardDeckColors.Two, "h") => (dict["Heart"], "heart_2.png"),
        (CardDeckColors.Two, "d") => (dict["Heart"], "diamond_2.png"),
        (CardDeckColors.Two, "c") => (dict["Spade"], "club_2.png"),
        (CardDeckColors.Four, "s") => (dict["Spade"], "spade_2.png"),
        (CardDeckColors.Four, "h") => (dict["Heart"], "heart_2.png"),
        (CardDeckColors.Four, "d") => (dict["Diamond"], "diamond_4.png"),
        (CardDeckColors.Four, "c") => (dict["Club"], "club_4.png"),
        _ => throw new ArgumentOutOfRangeException($"{nameof(colorType)}:{nameof(suite)} combination out of range. Values were: {colorType}:{suite}")
    };
}