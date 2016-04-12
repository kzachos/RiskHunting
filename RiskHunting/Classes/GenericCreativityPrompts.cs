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

		public GenericCreativityPrompts (string filler, string type, CultureInfo currentCulture)
		{
			this.genericCPs = new List<string> ();

			if (currentCulture.ToString ().Contains ("en")) {
				if (type.Equals ("NP")) {
					this.genericCPs.Add ("Think about how to make the *" + filler + "* move and adjust");
					this.genericCPs.Add ("Think about doing the opposite of what is expected with the *" + filler + "*");
					this.genericCPs.Add ("Think about if you can replace something mechanical in the *" + filler + "* with something that is sensory");
					this.genericCPs.Add ("Think about if it is possible to change the density of the *" + filler + "*");
					this.genericCPs.Add ("Think about if it is possible to change the temperature of the *" + filler + "*");
					this.genericCPs.Add ("Think about making the *" + filler + "* more flexible");
					this.genericCPs.Add ("Think about how to use liquid or air with the *" + filler + "*");
					this.genericCPs.Add ("Think about if it is possible to regenerate the *" + filler + "*");
					this.genericCPs.Add ("Think about how you provide a shell or cover for the *" + filler + "*");
					this.genericCPs.Add ("Think about whether you can make a copy of the *" + filler + "*");
					this.genericCPs.Add ("Think about how you might combine the *" + filler + "* with something else");
					this.genericCPs.Add ("Think about if you could make do with more of the *" + filler + "*, or less of the *" + filler + "*");
					this.genericCPs.Add ("Think about whether you can balance the *" + filler + "* with something else");
					this.genericCPs.Add ("Think about how to make the *" + filler + "* work before it is needed");
					this.genericCPs.Add ("Think about how to make the *" + filler + "* do lots of different things");
					this.genericCPs.Add ("Think about how to introduce feedback into the *" + filler + "*");
					this.genericCPs.Add ("Think about how to make the *" + filler + "* self-sustaining, so that it uses all of its waste");
					this.genericCPs.Add ("Think about how to remove something from the *" + filler + "*");
					this.genericCPs.Add ("Think about how to avoid stress in the *" + filler + "*, and/or the situation, before it happens");
					this.genericCPs.Add ("Think about how to make parts or all of the *" + filler + "* move and adjust");
					this.genericCPs.Add ("Think about how to make the *" + filler + "* vibrate");
					this.genericCPs.Add ("Think about whether it is possible to make the *" + filler + "* change itself, release or absorb energy");
					this.genericCPs.Add ("Think about whether it is possible to make the *" + filler + "* an irregular shape");
					this.genericCPs.Add ("Think about trying to put the *" + filler + "* inside another thing, inside another thing");
					this.genericCPs.Add ("Think about making the *" + filler + "* more spherical or circular");
					this.genericCPs.Add ("Think about making all of the part of the *" + filler + "* of one substance");
					this.genericCPs.Add ("Think about dividing the *" + filler + "* up");
					this.genericCPs.Add ("Think about making the *" + filler + "* either transparent or a different colour");
					this.genericCPs.Add ("Think about trying to make the *" + filler + "* expand or contract in response to its environment");
					this.genericCPs.Add ("Think about either trying to put holes in the *" + filler + "* or to fill holes in the *" + filler + "*");
					this.genericCPs.Add ("Think about making the *" + filler + "* cheap and disposable");
					this.genericCPs.Add ("Think about making the *" + filler + "* pulse");
					this.genericCPs.Add ("Think about putting the *" + filler + "* in a vacuum");
					this.genericCPs.Add ("Think about deactivating the *" + filler + "*");
					this.genericCPs.Add ("Think about evening out the environmental forces that affect the *" + filler + "*");
				} else if (type.Equals ("VP")) {
					this.genericCPs.Add ("Think about using materials that are composed of many things during *" + filler + "*");
					this.genericCPs.Add ("Think about how to speed up *" + filler + "*");
					this.genericCPs.Add ("Think about whether you can repeat *" + filler + "*");
					this.genericCPs.Add ("Think about if you can use a messenger of some form in conjunction with *" + filler + "*");
					this.genericCPs.Add ("Think about how to introduce feedback during *" + filler + "*");
					this.genericCPs.Add ("Think about making *" + filler + "* self-sustaining, so that it recycles all of its waste");
					this.genericCPs.Add ("Think about how to remove a step from *" + filler + "*");
					this.genericCPs.Add ("Think about having an emergency plan in place for *" + filler + "*");
					this.genericCPs.Add ("Think about how to distribute *" + filler + "*");
					this.genericCPs.Add ("Think about how to add or use an extra dimension during *" + filler + "*");
					this.genericCPs.Add ("Think about trying to enrich the environment in which *" + filler + "* take place");
					this.genericCPs.Add ("Think about making something pulse during *" + filler + "*");
					this.genericCPs.Add ("Think about evening out environmental forces that occur during *" + filler + "*");
				} else
					this.genericCPs.Add ("");
			}
			else if (currentCulture.ToString ().Contains ("it")) {
				if (type.Equals ("NP")) {
					this.genericCPs.Add ("Pensa a come far *" + filler + "* muoversi e regolarsi");
					this.genericCPs.Add ("Pensa a fare il contrario di ciòhe èrevisto con il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se puoi sostituire qualcosa di meccanico nel *" + filler + "* con qualcosa che èensoriale");
					this.genericCPs.Add ("Pensa a se èossibile modificare la densitàel *" + filler + "*");
					this.genericCPs.Add ("Pensa a se èossibile variare la temperatura del *" + filler + "*");
					this.genericCPs.Add ("Pensa a rendendo il *" + filler + "* piùlessibile");
					this.genericCPs.Add ("Pensa a come utilizzare liquidi o aria con il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se èossibile rigenerare il *" + filler + "*");
					this.genericCPs.Add ("Pensa a come fornire una conchiglia o copertura per il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se èossibile fare una copia del *" + filler + "*");
					this.genericCPs.Add ("Pensa a come si potrebbe combinare il *" + filler + "* con qualcos'altro");
					this.genericCPs.Add ("Pensa a Se potessi fare di piu' con il *" + filler + "* o di meno con il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se èossibile bilanciare il *" + filler + "* con qualcos'altro");
					this.genericCPs.Add ("Pensa a come far il *" + filler + "* funzionare prima che sia necessario");
					this.genericCPs.Add ("Pensa a come far il *" + filler + "* fare un sacco di cose diverse");
					this.genericCPs.Add ("Pensa a come introdurre feedback nel di *" + filler + "*");
					this.genericCPs.Add ("Pensa a come far il *" + filler + "* autosufficiente , in modo che utilizzi tutti i suoi rifiuti");
					this.genericCPs.Add ("Pensa a come rimuovere qualcosa dal *" + filler + "* *" + filler + "*");
					this.genericCPs.Add ("Pensa a come evitare lo stress nel *" + filler + "*, e / o la situazione, prima che accada");
					this.genericCPs.Add ("Pensa a Come far in modo che parte o tutto il di *" + filler + "* si muovi e si regoli da solo");
					this.genericCPs.Add ("Pensa a come fare vibrare il *" + filler + "* *" + filler + "*");
					this.genericCPs.Add ("Pensa a se è possibile far in modo che il *" + filler + "* si cambi da solo, rilasci o assorbi energia");
					this.genericCPs.Add ("Pensa a se è possibile fare il *" + filler + "* in una forma irregolare");
					this.genericCPs.Add ("Pensa a cercar di mettere il *" + filler + "* all'interno di un'altra cosa , all'interno di un'altra cosa");
					this.genericCPs.Add ("Pensa a rendendo il *" + filler + "* più sferico o circolare");
					this.genericCPs.Add ("Pensa a rendendo tutte le parte del *" + filler + "* di una sostanza sola");
					this.genericCPs.Add ("Pensa a dividendo il *" + filler + "* in");
					this.genericCPs.Add ("Pensa a rendendo il  *" + filler + "* trasparente o di un colore diverso");
					this.genericCPs.Add ("Pensa a cercando di fare in modo che il *" + filler + "* si espanda o contratti  a seconda dell'ambiente");
					this.genericCPs.Add ("Pensa a cercando di mettere buchi nel *" + filler + "* o riempire i buchi nel *" + filler + "*");
					this.genericCPs.Add ("Pensa a rendendo il *" + filler + "* a basso costo ed usa e getta");
					this.genericCPs.Add ("Pensa a far in modo che il *" + filler + "* pulsi");
					this.genericCPs.Add ("Pensa a metter il *" + filler + "* in un aspirapolvere");
					this.genericCPs.Add ("Pensa a disattivazione del *" + filler + "*");
					this.genericCPs.Add ("Pensa a uniformare le forze ambientali che influenzano il *" + filler + "*");
				}  
				else if (type.Equals ("VP")) {
					this.genericCPs.Add ("Pensa a utilizzando materiali che sono composti da molte cose durante *" + filler + "*");
					this.genericCPs.Add ("Pensa a come accelerare il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se è possibile ripetere il *" + filler + "*");
					this.genericCPs.Add ("Pensa a se è possibile utilizzare un messaggero di qualsiasi forma in collaborazione con *" + filler + "*");
					this.genericCPs.Add ("Pensa a come introdurre feedback durante il *" + filler + "*");
					this.genericCPs.Add ("Pensa a rendendo il *" + filler + "* autosufficiente, in modo che ricicla tutti i suoi rifiuti");
					this.genericCPs.Add ("Pensa a come rimuovere un passo dal *" + filler + "*");
					this.genericCPs.Add ("Pensa a avere un piano di emergenza in atto per *" + filler + "*");
					this.genericCPs.Add ("Pensa a come distribuire il *" + filler + "*");
					this.genericCPs.Add ("Pensa a come aggiungere o utilizzare una dimensione extra durante il *" + filler + "*");
					this.genericCPs.Add ("Pensa a cercando di arricchire l'ambiente in cui *" + filler + "* avviene");
					this.genericCPs.Add ("Pensa a far pulsare qualcosa durante il *" + filler + "*");
					this.genericCPs.Add ("Pensa a uniformare le forze ambientali che si verificano durante il *" + filler + "*");
				}
				else
					this.genericCPs.Add ("");
			}
				
		}


	}
}

