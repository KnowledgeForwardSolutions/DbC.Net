namespace DbC.Net.FloatingPoint;

public class StandardFloatingPointComparers
{
   private static readonly Lazy<FixedEpsilonComparer<Decimal>> _decimalFixedEpsilonComparer =
      new(() => new FixedEpsilonComparer<Decimal>());
   private static readonly Lazy<FixedEpsilonComparer<Double>> _doubleFixedEpsilonComparer =
      new(() => new FixedEpsilonComparer<Double>());
   private static readonly Lazy<FixedEpsilonComparer<Half>> _halfFixedEpsilonComparer =
      new(() => new FixedEpsilonComparer<Half>());
   private static readonly Lazy<FixedEpsilonComparer<Single>> _singleFixedEpsilonComparer =
      new(() => new FixedEpsilonComparer<Single>());

   private static readonly Lazy<DoubleRelativeErrorComparer> _doubleRelativeErrorComparer =
      new(() => new DoubleRelativeErrorComparer());
   private static readonly Lazy<HalfRelativeErrorComparer> _halfRelativeErrorComparer =
      new(() => new HalfRelativeErrorComparer());
   private static readonly Lazy<SingleRelativeErrorComparer> _singleRelativeErrorComparer =
      new(() => new SingleRelativeErrorComparer());

   /// <summary>
   ///   Fixed epsilon comparer for type <see cref="Decimal"/>.
   /// </summary>
   public static FixedEpsilonComparer<Decimal> DecimalFixedEpsilonComparer => _decimalFixedEpsilonComparer.Value;

   /// <summary>
   ///   Fixed epsilon comparer for type <see cref="Double"/>.
   /// </summary>
   public static FixedEpsilonComparer<Double> DoubleFixedEpsilonComparer => _doubleFixedEpsilonComparer.Value;

   /// <summary>
   ///   Fixed epsilon comparer for type <see cref="Half"/>.
   /// </summary>
   public static FixedEpsilonComparer<Half> HalfFixedEpsilonComparer => _halfFixedEpsilonComparer.Value;

   /// <summary>
   ///   Fixed epsilon comparer for type <see cref="Single"/>.
   /// </summary>
   public static FixedEpsilonComparer<Single> SingleFixedEpsilonComparer => _singleFixedEpsilonComparer.Value;

   /// <summary>
   ///   Relative error comparer for type <see cref="Double"/>.
   /// </summary>
   public static DoubleRelativeErrorComparer DoubleRelativeErrorComparer => _doubleRelativeErrorComparer.Value;

   /// <summary>
   ///   Relative error comparer for type <see cref="Half"/>.
   /// </summary>
   public static HalfRelativeErrorComparer HalfRelativeErrorComparer => _halfRelativeErrorComparer.Value;

   /// <summary>
   ///   Relative error comparer for type <see cref="Single"/>.
   /// </summary>
   public static SingleRelativeErrorComparer SingleRelativeErrorComparer => _singleRelativeErrorComparer.Value;
}
