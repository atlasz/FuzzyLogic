
namespace Zkull.Fuzzy
{
	public class FuzzyTerm 
	{

		//all terms must implement a virtual constructor
		public virtual FuzzyTerm Clone(){return new FuzzyTerm();}

		//retrieves the degree of membership of the term
		public virtual float GetDOM(){ return 1f;}

		//clears the degree of membership of the term
		public virtual void ClearDOM(){}

		//method for updating the DOM of a consequent when a rule fires
		public virtual void ORwithDOM(float val){}
	}
}

