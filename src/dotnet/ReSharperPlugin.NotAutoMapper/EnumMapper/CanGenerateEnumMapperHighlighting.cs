using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

// ReSharper disable ArgumentsStyleLiteral
// ReSharper disable ArgumentsStyleNamedExpression
// ReSharper disable ArgumentsStyleOther

namespace ReSharperPlugin.NotAutoMapper.EnumMapper
{
    [RegisterConfigurableSeverity(
        ID: nameof(CanGenerateEnumMapperHighlighting),
        CompoundItemName: null,
        Group: HighlightingGroupIds.BestPractice,
        Title: Message,
        Description: null,
        DefaultSeverity: Severity.SUGGESTION)]
    [ConfigurableSeverityHighlighting(
        nameof(CanGenerateEnumMapperHighlighting),
        CSharpLanguage.Name,
        OverlapResolve = OverlapResolveKind.NONE,
        OverloadResolvePriority = int.MaxValue,
        ToolTipFormatString = Message)]
    public class CanGenerateEnumMapperHighlighting : IHighlighting
    {
        private const string Message = "Can generate enum mapper method";

        public string ToolTip => Message;

        public string ErrorStripeToolTip => "Generate enum mapper method";

        public CanGenerateEnumMapperHighlighting(IMethodDeclaration declaration)
        {
            Declaration = declaration;
        }

        public IMethodDeclaration Declaration { get; }

        // Actual check is performed in ProblemAnalyzer
        public bool IsValid() => true;

        public DocumentRange CalculateRange()
        {
            return Declaration.GetDocumentRange();
        }
    }
}