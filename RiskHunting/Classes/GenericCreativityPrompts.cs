using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace RiskHunting
{
	public class GenericCreativityPrompts
	{
		public List<string> genericCPs; 

		public GenericCreativityPrompts (string filler, string type)
		{
			this.genericCPs = new List<string> ();

			CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
			switch (currentCulture.ToString())
			{
			case "en":
				if (type.Equals ("NP")) {
					this.genericCPs.Add ("how to make the " + filler + " move and adjust");
					this.genericCPs.Add ("doing the opposite of what is expected with the " + filler);
					this.genericCPs.Add ("if you can replace something mechanical in the " + filler + " with something that is sensory");
					this.genericCPs.Add ("if it is possible to change the density of the " + filler);
					this.genericCPs.Add ("if it is possible to change the temperature of the " + filler);
					this.genericCPs.Add ("making the " + filler + " more flexible");
					this.genericCPs.Add ("how to use liquid or air with the " + filler);
					this.genericCPs.Add ("if it is possible to regenerate the " + filler);
					this.genericCPs.Add ("how you provide a shell or cover for the " + filler);
					this.genericCPs.Add ("whether you can make a copy of the " + filler);
					this.genericCPs.Add ("how you might combine the " + filler + " with something else");
					this.genericCPs.Add ("if you could make do with more of the " + filler + ", or less of the " + filler);
					this.genericCPs.Add ("whether you can balance the " + filler + " with something else");
					this.genericCPs.Add ("how to make the " + filler + " work before it is needed");
					this.genericCPs.Add ("how to make the " + filler + " do lots of different things");
					this.genericCPs.Add ("how to introduce feedback into the " + filler);
					this.genericCPs.Add ("how to make the " + filler + " self-sustaining, so that it uses all of its waste");
					this.genericCPs.Add ("how to remove something from the " + filler);
					this.genericCPs.Add ("how to avoid stress in the " + filler + ", and/or the situation, before it happens");
					this.genericCPs.Add ("how to make parts or all of the " + filler + " move and adjust");
					this.genericCPs.Add ("how to make the " + filler + " vibrate");
					this.genericCPs.Add ("whether it is possible to make the " + filler + " change itself, release or absorb energy");
					this.genericCPs.Add ("whether it is possible to make the " + filler + " an irregular shape");
					this.genericCPs.Add ("trying to put the " + filler + " inside another thing, inside another thing");
					this.genericCPs.Add ("making the " + filler + " more spherical or circular");
					this.genericCPs.Add ("making all of the part of the " + filler + " of one substance");
					this.genericCPs.Add ("dividing the " + filler + " up");
					this.genericCPs.Add ("making the " + filler + " either transparent or a different colour");
					this.genericCPs.Add ("trying to make the " + filler + " expand or contract in response to its environment");
					this.genericCPs.Add ("either trying to put holes in the " + filler + " or to fill holes in the " + filler);
					this.genericCPs.Add ("making the " + filler + " cheap and disposable");
					this.genericCPs.Add ("making the " + filler + " pulse");
					this.genericCPs.Add ("putting the " + filler + " in a vacuum");
					this.genericCPs.Add ("deactivating the " + filler);
					this.genericCPs.Add ("evening out the environmental forces that affect the " + filler);
				} 
				else if (type.Equals ("VP")) {
					this.genericCPs.Add ("using materials that are composed of many things during " + filler);
					this.genericCPs.Add ("how to speed up " + filler);
					this.genericCPs.Add ("whether you can repeat " + filler);
					this.genericCPs.Add ("if you can use a messenger of some form in conjunction with " + filler);
					this.genericCPs.Add ("how to introduce feedback during " + filler);
					this.genericCPs.Add ("making " + filler + " self-sustaining, so that it recycles all of its waste");
					this.genericCPs.Add ("how to remove a step from " + filler);
					this.genericCPs.Add ("having an emergency plan in place for " + filler);
					this.genericCPs.Add ("how to distribute " + filler);
					this.genericCPs.Add ("how to add or use an extra dimension during " + filler);
					this.genericCPs.Add ("trying to enrich the environment in which " + filler + " take place");
					this.genericCPs.Add ("making something pulse during " + filler);
					this.genericCPs.Add ("evening out environmental forces that occur during " + filler);
				}
				else
					this.genericCPs.Add ("");
				break;
			case "it":
				if (type.Equals ("NP")) {
					this.genericCPs.Add ("come far " + filler + " muoversi e regolarsi");
					this.genericCPs.Add ("fare il contrario di ciòhe èrevisto con il " + filler);
					this.genericCPs.Add ("se puoi sostituire qualcosa di meccanico nel " + filler + " con qualcosa che èensoriale");
					this.genericCPs.Add ("se èossibile modificare la densitàel " + filler);
					this.genericCPs.Add ("se èossibile variare la temperatura del " + filler);
					this.genericCPs.Add ("rendendo il " + filler + " piùlessibile");
					this.genericCPs.Add ("come utilizzare liquidi o aria con il " + filler);
					this.genericCPs.Add ("se èossibile rigenerare il " + filler);
					this.genericCPs.Add ("come fornire una conchiglia o copertura per il " + filler);
					this.genericCPs.Add ("se èossibile fare una copia del " + filler);
					this.genericCPs.Add ("come si potrebbe combinare il " + filler + " con qualcos'altro");
					this.genericCPs.Add ("Se potessi fare di piu' con il " + filler + " o di meno con il " + filler);
					this.genericCPs.Add ("se èossibile bilanciare il " + filler + " con qualcos'altro");
					this.genericCPs.Add ("come far il " + filler + " funzionare prima che sia necessario");
					this.genericCPs.Add ("come far il " + filler + " fare un sacco di cose diverse");
					this.genericCPs.Add ("come introdurre feedback nel di " + filler);
					this.genericCPs.Add ("come far il " + filler + " autosufficiente , in modo che utilizzi tutti i suoi rifiuti");
					this.genericCPs.Add ("come rimuovere qualcosa dal " + filler + " " + filler);
					this.genericCPs.Add ("come evitare lo stress nel " + filler + ", e / o la situazione, prima che accada");
					this.genericCPs.Add ("Come far in modo che parte o tutto il di " + filler + " si muovi e si regoli da solo");
					this.genericCPs.Add ("come fare vibrare il " + filler + " " + filler);
					this.genericCPs.Add ("se è possibile far in modo che il " + filler + " si cambi da solo, rilasci o assorbi energia");
					this.genericCPs.Add ("se è possibile fare il " + filler + " in una forma irregolare");
					this.genericCPs.Add ("cercar di mettere il " + filler + " all'interno di un'altra cosa , all'interno di un'altra cosa");
					this.genericCPs.Add ("rendendo il " + filler + " più sferico o circolare");
					this.genericCPs.Add ("rendendo tutte le parte del " + filler + " di una sostanza sola");
					this.genericCPs.Add ("dividendo il " + filler + " in");
					this.genericCPs.Add ("rendendo il  " + filler + " trasparente o di un colore diverso");
					this.genericCPs.Add ("cercando di fare in modo che il " + filler + " si espanda o contratti  a seconda dell'ambiente");
					this.genericCPs.Add ("cercando di mettere buchi nel " + filler + " o riempire i buchi nel " + filler);
					this.genericCPs.Add ("rendendo il " + filler + " a basso costo ed usa e getta");
					this.genericCPs.Add ("far in modo che il " + filler + " pulsi");
					this.genericCPs.Add ("metter il " + filler + " in un aspirapolvere");
					this.genericCPs.Add ("disattivazione del " + filler);
					this.genericCPs.Add ("uniformare le forze ambientali che influenzano il " + filler);
				}  
				else if (type.Equals ("VP")) {
					this.genericCPs.Add ("utilizzando materiali che sono composti da molte cose durante " + filler);
					this.genericCPs.Add ("come accelerare il " + filler);
					this.genericCPs.Add ("se è possibile ripetere il " + filler);
					this.genericCPs.Add ("se è possibile utilizzare un messaggero di qualsiasi forma in collaborazione con " + filler);
					this.genericCPs.Add ("come introdurre feedback durante il " + filler);
					this.genericCPs.Add ("rendendo il " + filler + " autosufficiente, in modo che ricicla tutti i suoi rifiuti");
					this.genericCPs.Add ("come rimuovere un passo dal " + filler);
					this.genericCPs.Add ("avere un piano di emergenza in atto per " + filler);
					this.genericCPs.Add ("come distribuire il " + filler);
					this.genericCPs.Add ("come aggiungere o utilizzare una dimensione extra durante il " + filler);
					this.genericCPs.Add ("cercando di arricchire l'ambiente in cui " + filler + " avviene");
					this.genericCPs.Add ("far pulsare qualcosa durante il " + filler);
					this.genericCPs.Add ("uniformare le forze ambientali che si verificano durante il " + filler);
				}
				else
					this.genericCPs.Add ("");
				break;
			}
				
		}


	}
}

