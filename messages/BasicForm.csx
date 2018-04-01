using System;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;

public enum Genres { Rock = 1, Pop, EDM, HipHop, Blues, Country, Jazz };
public enum Vocalists { Male = 1, Female, NoPreference };
public enum Feeling { Uplifting = 1, Introspective, Mellow, Angry }

public enum Choices1 { ElvisPresley = 1, KatyPerry }
public enum Choices2 { JohnLeeHooker = 1, FatBoySlim }
public enum Choices3 { Kiss = 1, Madonna }

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Please select your favorite music {&} {||}")]
    public Genres Genre { get; set; }

    [Prompt("Please select your typical {&} preference {||}")]
    public Vocalists Vocalist { get; set; }

    [Prompt("What sort of vibe are you feeling {||}")]
    public Feeling Feeling { get; set; }

    [Prompt("Who do you prefer... {||}")]
    public Choices1 Choice1 { get; set; }

    [Prompt("Who do you prefer... {||}", ChoiceStyle = ChoiceStyleOptions.Carousel)]
    public Choices2 Choice2 { get; set; }

    [Prompt("Who do you prefer... {||}")]
    public Choices3 Choice3 { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        return new FormBuilder<BasicForm>()
                    .AddRemainingFields()
                    .Build();

        //return new FormBuilder<BasicForm>()
        //            .Field(nameof(Genre))
        //            .Field(nameof(Vocalist))
        //            .Field(nameof(Feeling))
        //            .Field(new FieldReflector<BasicForm>(nameof(Choice1))
        //                .SetDefine(async (state, field) =>
        //                {
        //                    field
        //                    .AddDescription(Choices1.ElvisPresley, Convert.ToString(Choices1.ElvisPresley), "https://newmusicbotb76a.blob.core.windows.net/media/Elvis-Presley-009-150x150.jpg")
        //                    .AddTerms(Choices1.ElvisPresley, Convert.ToString(Choices1.ElvisPresley))

        //                    .AddDescription(Choices1.KatyPerry, Convert.ToString(Choices1.KatyPerry), "https://newmusicbotb76a.blob.core.windows.net/media/katy_perry_th_009.jpg")
        //                    .AddTerms(Choices1.KatyPerry, Convert.ToString(Choices1.KatyPerry));

        //                    return true;
        //                }));
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
