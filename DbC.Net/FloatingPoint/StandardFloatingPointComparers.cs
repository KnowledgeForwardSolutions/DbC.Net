namespace DbC.Net.FloatingPoint;

public class StandardFloatingPointComparers
{
   private static readonly Lazy<FixedErrorComparer<Decimal>> _decimalFixedErrorComparer =
      new(() => new FixedErrorComparer<Decimal>());
   private static readonly Lazy<FixedErrorComparer<Double>> _doubleFixedErrorComparer =
      new(() => new FixedErrorComparer<Double>());
   private static readonly Lazy<FixedErrorComparer<Half>> _halfFixedErrorComparer =
      new(() => new FixedErrorComparer<Half>());
   private static readonly Lazy<FixedErrorComparer<Single>> _singleFixedErrorComparer =
      new(() => new FixedErrorComparer<Single>());

   private static readonly Lazy<DoubleRelativeErrorComparer> _doubleRelativeErrorComparer =
      new(() => new DoubleRelativeErrorComparer());
   private static readonly Lazy<HalfRelativeErrorComparer> _halfRelativeErrorComparer =
      new(() => new HalfRelativeErrorComparer());
   private static readonly Lazy<SingleRelativeErrorComparer> _singleRelativeErrorComparer =
      new(() => new SingleRelativeErrorComparer());

   /// <summary>
   ///   Fixed error comparer for type <see cref="Decimal"/>.
   /// </summary>
   public static FixedErrorComparer<Decimal> DecimalFixedErrorComparer => _decimalFixedErrorComparer.Value;

   /// <summary>
   ///   Fixed error comparer for type <see cref="Double"/>.
   /// </summary>
   public static FixedErrorComparer<Double> DoubleFixedErrorComparer => _doubleFixedErrorComparer.Value;

   /// <summary>
   ///   Fixed error comparer for type <see cref="Half"/>.
   /// </summary>
   public static FixedErrorComparer<Half> HalfFixedErrorComparer => _halfFixedErrorComparer.Value;

   /// <summary>
   ///   Fixed error comparer for type <see cref="Single"/>.
   /// </summary>
   public static FixedErrorComparer<Single> SingleFixedErrorComparer => _singleFixedErrorComparer.Value;

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
