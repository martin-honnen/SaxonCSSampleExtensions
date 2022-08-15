using Saxon.Api;

namespace SaxonCSSampleExtensions
{
    /// <summary>
    /// Example extension function to compute a square root, using the full API
    /// </summary>

    public class Sqrt : ExtensionFunctionDefinition
    {
        public override QName FunctionName => new QName("http://example.com/math", "sqrt");

        public override int MinimumNumberOfArguments => 1;

        public override int MaximumNumberOfArguments => 1;

        public override XdmSequenceType[] ArgumentTypes =>
        new[]{
                new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_DOUBLE), '?')
            };

        public override XdmSequenceType ResultType(XdmSequenceType[] ArgumentTypes)
        {
            return new(XdmAtomicType.BuiltInAtomicType(QName.XS_DOUBLE), '?');
        }

        public override bool TrustResultType => true;


        public override ExtensionFunctionCall MakeFunctionCall()
        {
            return new SqrtCall();
        }
    }

    internal class SqrtCall : ExtensionFunctionCall
    {
        public override XdmValue Call(XdmValue[] arguments, DynamicContext context)
        {
            if (arguments[0].Empty)
            {
                return XdmEmptySequence.Instance;
            }
            XdmAtomicValue arg = (XdmAtomicValue)arguments[0].ItemAt(0);
            double val = (double)arg.Value;
            double sqrt = System.Math.Sqrt(val);
            return new XdmAtomicValue(sqrt);
        }
    }
}