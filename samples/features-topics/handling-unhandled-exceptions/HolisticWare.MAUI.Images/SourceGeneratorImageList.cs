using System;
//using Microsoft.CodeAnalysis;

namespace HolisticWare.MAUI.Images;

/*
[Generator]
public sealed partial class 
                                        SourceGeneratorImageList
                                        :
                                        IIncrementalGenerator
{
    public
        void
                                        Initialize
                                        (
                                            IncrementalGeneratorInitializationContext context
                                        )
    {
        IncrementalValuesProvider<AdditionalText> ymlFiles 
                            = context.AdditionalTextsProvider.Where
                                                                (
                                                                    static file => file.Path.EndsWith(".png")
                                                                );
        // /*
         Images are binary so no need to read them
        //* /
        IncrementalValuesProvider<string> ymlFileContents 
                            = ymlFiles.Select
                                        (
                                            (text, cancellationToken) => text.GetText(cancellationToken)!.ToString()
                                        );
        
        return;
    }
}
*/