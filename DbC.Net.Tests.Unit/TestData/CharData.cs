namespace DbC.Net.Tests.Unit.TestData;

public class CharData : ComparableValue<Char>
{
   public CharData() : base(
      'A',
      'z',
      Comparer<Char>.Default,
      new ReverseComparer<Char>(),
      Char.MinValue,
      Char.MaxValue,
      'A',
      'Z',
      '*',
      'M',
      '~')
   { }
}
