using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

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
					this.genericCPs.Add ("Think about how to make the " + filler + " move and adjust");
					this.genericCPs.Add ("Think about doing the opposite of what is expected with the " + filler + "");
					this.genericCPs.Add ("Think about if you can replace something mechanical in the " + filler + " with something that is sensory");
					this.genericCPs.Add ("Think about if it is possible to change the density of the " + filler + "");
					this.genericCPs.Add ("Think about if it is possible to change the temperature of the " + filler + "");
					this.genericCPs.Add ("Think about making the " + filler + " more flexible");
					this.genericCPs.Add ("Think about how to use liquid or air with the " + filler + "");
					this.genericCPs.Add ("Think about if it is possible to regenerate the " + filler + "");
					this.genericCPs.Add ("Think about how you provide a shell or cover for the " + filler + "");
					this.genericCPs.Add ("Think about whether you can make a copy of the " + filler + "");
					this.genericCPs.Add ("Think about how you might combine the " + filler + " with something else");
					this.genericCPs.Add ("Think about if you could make do with more of the " + filler + ", or less of the " + filler + "");
					this.genericCPs.Add ("Think about whether you can balance the " + filler + " with something else");
					this.genericCPs.Add ("Think about how to make the " + filler + " work before it is needed");
					this.genericCPs.Add ("Think about how to make the " + filler + " do lots of different things");
					this.genericCPs.Add ("Think about how to introduce feedback into the " + filler + "");
					this.genericCPs.Add ("Think about how to make the " + filler + " self-sustaining, so that it uses all of its waste");
					this.genericCPs.Add ("Think about how to remove something from the " + filler + "");
					this.genericCPs.Add ("Think about how to avoid stress in the " + filler + ", and/or the situation, before it happens");
					this.genericCPs.Add ("Think about how to make parts or all of the " + filler + " move and adjust");
					this.genericCPs.Add ("Think about how to make the " + filler + " vibrate");
					this.genericCPs.Add ("Think about whether it is possible to make the " + filler + " change itself, release or absorb energy");
					this.genericCPs.Add ("Think about whether it is possible to make the " + filler + " an irregular shape");
					this.genericCPs.Add ("Think about trying to put the " + filler + " inside another thing, inside another thing");
					this.genericCPs.Add ("Think about making the " + filler + " more spherical or circular");
					this.genericCPs.Add ("Think about making all of the part of the " + filler + " of one substance");
					this.genericCPs.Add ("Think about dividing the " + filler + " up");
					this.genericCPs.Add ("Think about making the " + filler + " either transparent or a different colour");
					this.genericCPs.Add ("Think about trying to make the " + filler + " expand or contract in response to its environment");
					this.genericCPs.Add ("Think about either trying to put holes in the " + filler + " or to fill holes in the " + filler + "");
					this.genericCPs.Add ("Think about making the " + filler + " cheap and disposable");
					this.genericCPs.Add ("Think about making the " + filler + " pulse");
					this.genericCPs.Add ("Think about putting the " + filler + " in a vacuum");
					this.genericCPs.Add ("Think about deactivating the " + filler + "");
					this.genericCPs.Add ("Think about evening out the environmental forces that affect the " + filler + "");
				} else if (type.Equals ("VP")) {
					this.genericCPs.Add ("Think about using materials that are composed of many things during " + filler + "");
					this.genericCPs.Add ("Think about how to speed up " + filler + "");
					this.genericCPs.Add ("Think about whether you can repeat " + filler + "");
					this.genericCPs.Add ("Think about if you can use a messenger of some form in conjunction with " + filler + "");
					this.genericCPs.Add ("Think about how to introduce feedback during " + filler + "");
					this.genericCPs.Add ("Think about making " + filler + " self-sustaining, so that it recycles all of its waste");
					this.genericCPs.Add ("Think about how to remove a step from " + filler + "");
					this.genericCPs.Add ("Think about having an emergency plan in place for " + filler + "");
					this.genericCPs.Add ("Think about how to distribute " + filler + "");
					this.genericCPs.Add ("Think about how to add or use an extra dimension during " + filler + "");
					this.genericCPs.Add ("Think about trying to enrich the environment in which " + filler + " take place");
					this.genericCPs.Add ("Think about making something pulse during " + filler + "");
					this.genericCPs.Add ("Think about evening out environmental forces that occur during " + filler + "");
				} else
					this.genericCPs.Add ("");
			}
			else if (currentCulture.ToString ().Contains ("it")) {
				if (type.Equals ("NP")) {
	
					char[] delim;
					var delim1 = new char[] { ' ' };
					var delim2 = new char[] { '\'' };
					var c = filler [1];
					if (c == '\'') 
						delim = delim2;			
					 else 
						delim = delim1;


					var words = filler.Split (delim, StringSplitOptions.RemoveEmptyEntries)
						.ToList ();
					var fillerLite = filler.Replace(words[0], "");

					string f_s_n, f_s_d, f_s_a, 
					f_p_n, f_p_d, f_p_a, 
					m_s_n, m_s_d, m_s_a, 
					m_p_n, m_p_d, m_p_a;

					if (c == '\'') {
						f_s_n = m_s_n = "nell";
						f_s_d = m_s_d = "dell";
						f_s_a = m_s_a = "all";
						m_p_n = "negli ";
						m_p_d = "degli ";
						m_p_a = "agli ";

					} else {
						string consonant1 = "zxs";
						string consonant2 = "ps";
						string consonant3 = "pn";
						string consonant4 = "gn";
						string vowel = "aeiou";
						if (
							consonant1.Contains(fillerLite[0]) ||
							fillerLite.StartsWith (consonant2, StringComparison.Ordinal) ||
							fillerLite.StartsWith (consonant3, StringComparison.Ordinal) ||
							fillerLite.StartsWith (consonant4, StringComparison.Ordinal) ||
							("i".Contains(fillerLite[0]) && vowel.Contains(fillerLite[1]))
							) {
							m_s_n = "nello ";
							m_s_d = "dello ";
							m_s_a = "allo ";							
							m_p_n = "negli ";
							m_p_d = "degli ";
							m_p_a = "agli ";
						} else {
							m_s_n = "nel ";
							m_s_d = "del ";
							m_s_a = "al ";	
							m_p_n = "nei ";
							m_p_d = "dei ";
							m_p_a = "ai ";
						}
						f_s_n = "nella ";
						f_s_d = "della ";
						f_s_a = "alla ";

					}
					f_p_n = "nelle ";
					f_p_d = "delle ";
					f_p_a = "alle ";

					if (filler.StartsWith ("la ", StringComparison.Ordinal) || 
						(filler.StartsWith ("l'", StringComparison.Ordinal) && filler.EndsWith ("a", StringComparison.Ordinal))) { // feminine singluar Determiners
						this.genericCPs.Add ("Pensa a come far " + filler + " muoversi e regolarsi");
						this.genericCPs.Add ("Pensa a fare il contrario di ciò che è previsto con " + filler + "");
						this.genericCPs.Add ("Pensa se puoi sostituire qualcosa di meccanico " + f_s_n + fillerLite + " con qualcosa che è sensoriale");
						this.genericCPs.Add ("Pensa se è possibile modificare la densità " + f_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa se è possibile variare la temperatura " + f_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più flessibile");
						this.genericCPs.Add ("Pensa a come utilizzare liquidi o aria con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile rigenerare " + filler + "");
						this.genericCPs.Add ("Pensa a come fornire una conchiglia o copertura per " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile fare una copia " + f_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come si potrebbe combinare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa se potessi fare di piu' con " + filler + " o di meno con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile bilanciare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa a come far funzionare " + filler + " prima che sia necessario");
						this.genericCPs.Add ("Pensa a come far fare " + f_s_a + fillerLite + " un sacco di cose diverse");
						this.genericCPs.Add ("Pensa a come introdurre feedback " + f_s_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a come far " + filler + " autosufficiente, in modo che utilizzino tutti i loro rifiuti");
						this.genericCPs.Add ("Pensa a come rimuovere qualcosa " + f_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come evitare lo stress " + f_s_n + fillerLite + ", e/o la situazione, prima che accada");
						this.genericCPs.Add ("Pensa a come far in modo che parte o tutto " + f_s_d + fillerLite + " si muovi e si regoli da solo");
						this.genericCPs.Add ("Pensa a come fare vibrare " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile far in modo che " + filler + " si cambino da sole, rilascino o assorbino energia");
						this.genericCPs.Add ("Pensa se è possibile fare " + filler + " in una forma irregolare");
						this.genericCPs.Add ("Pensa a cercar di mettere " + filler + " all'interno di un'altra cosa");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più sferiche o circolari");
						this.genericCPs.Add ("Pensa a rendere tutte le parti " + f_s_d + fillerLite + " di una sostanza sola");
						this.genericCPs.Add ("Pensa a dividere " + filler + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " trasparente o di un colore diverso");
						this.genericCPs.Add ("Pensa a come fare in modo che " + filler + " si espandano o contraggano  a seconda dell'ambiente");
						this.genericCPs.Add ("Pensa a come mettere buchi " + f_s_n + fillerLite + " o riempire i buchi " + f_s_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " a basso costo ed usa e getta");
						this.genericCPs.Add ("Pensa a far in modo che " + filler + " pulsino");
						this.genericCPs.Add ("Pensa a metter " + filler + " in un aspirapolvere");
						this.genericCPs.Add ("Pensa a disattivare " + filler + "");
						this.genericCPs.Add ("Pensa ad uniformare le forze ambientali che influenzano " + filler + "");
					}
					else if (filler.StartsWith ("le ", StringComparison.Ordinal)) { // feminine plural Determiners
						this.genericCPs.Add ("Pensa a come far " + filler + " muoversi e regolarsi");
						this.genericCPs.Add ("Pensa a fare il contrario di ciò che è previsto con " + filler + "");
						this.genericCPs.Add ("Pensa se puoi sostituire qualcosa di meccanico " + f_p_n + fillerLite + " con qualcosa che è sensoriale");
						this.genericCPs.Add ("Pensa se è possibile modificare la densità " + f_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa se è possibile variare la temperatura " + f_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più flessibile");
						this.genericCPs.Add ("Pensa a come utilizzare liquidi o aria con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile rigenerare " + filler + "");
						this.genericCPs.Add ("Pensa a come fornire una conchiglia o copertura per " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile fare una copia " + f_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come si potrebbe combinare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa se potessi fare di piu' con " + filler + " o di meno con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile bilanciare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa a come far funzionare " + filler + " prima che sia necessario");
						this.genericCPs.Add ("Pensa a come far fare  " + f_p_a + fillerLite + " un sacco di cose diverse");
						this.genericCPs.Add ("Pensa a come introdurre feedback " + f_p_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a come far " + filler + " autosufficiente, in modo che utilizzino tutti i loro rifiuti");
						this.genericCPs.Add ("Pensa a come rimuovere qualcosa " + f_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come evitare lo stress " + f_p_n + fillerLite + ", e/o la situazione, prima che accada");
						this.genericCPs.Add ("Pensa a come far in modo che parte o tutto " + f_p_d + fillerLite + " si muovi e si regoli da solo");
						this.genericCPs.Add ("Pensa a come fare vibrare " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile far in modo che " + filler + " si cambino da sole, rilascino o assorbino energia");
						this.genericCPs.Add ("Pensa se è possibile fare " + filler + " in una forma irregolare");
						this.genericCPs.Add ("Pensa a cercar di mettere " + filler + " all'interno di un'altra cosa");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più sferiche o circolari");
						this.genericCPs.Add ("Pensa a rendere tutte le parti " + f_p_d + fillerLite + " di una sostanza sola");
						this.genericCPs.Add ("Pensa a dividere " + filler + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " trasparente o di un colore diversi");
						this.genericCPs.Add ("Pensa a come fare in modo che " + filler + " si espandano o contraggano  a seconda dell'ambiente");
						this.genericCPs.Add ("Pensa a come mettere buchi " + f_p_n + fillerLite + " o riempire i buchi " + f_p_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " a basso costo ed usa e getta");
						this.genericCPs.Add ("Pensa a far in modo che " + filler + " pulsino");
						this.genericCPs.Add ("Pensa a metter " + filler + " in un aspirapolvere");
						this.genericCPs.Add ("Pensa a disattivare " + filler + "");
						this.genericCPs.Add ("Pensa ad uniformare le forze ambientali che influenzano " + filler + "");
					}
					else if (filler.StartsWith ("il ", StringComparison.Ordinal) || filler.StartsWith ("lo ", StringComparison.Ordinal) || 
						(filler.StartsWith ("l'", StringComparison.Ordinal) && (filler.EndsWith ("e", StringComparison.Ordinal) || filler.EndsWith ("u", StringComparison.Ordinal) || filler.EndsWith ("o", StringComparison.Ordinal)))) { // masculine singluar Determiners
						this.genericCPs.Add ("Pensa a come far " + filler + " muoversi e regolarsi");
						this.genericCPs.Add ("Pensa a fare il contrario di ciò che è previsto con " + filler + "");
						this.genericCPs.Add ("Pensa se puoi sostituire qualcosa di meccanico " + m_s_n + fillerLite + " con qualcosa che è sensoriale");
						this.genericCPs.Add ("Pensa se è possibile modificare la densità " + m_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa se è possibile variare la temperatura " + m_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più flessibile");
						this.genericCPs.Add ("Pensa a come utilizzare liquidi o aria con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile rigenerare " + filler + "");
						this.genericCPs.Add ("Pensa a come fornire una conchiglia o copertura per " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile fare una copia " + m_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come si potrebbe combinare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa se potessi fare di piu' con " + filler + " o di meno con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile bilanciare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa a come far funzionare " + filler + " prima che sia necessario");
						this.genericCPs.Add ("Pensa a come far fare  " + m_s_a + fillerLite + " un sacco di cose diverse");
						this.genericCPs.Add ("Pensa a come introdurre feedback " + m_s_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a come far " + filler + " autosufficiente, in modo che utilizzi tutti i suoi rifiuti");
						this.genericCPs.Add ("Pensa a come rimuovere qualcosa " + m_s_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come evitare lo stress " + m_s_n + fillerLite + ", e/o la situazione, prima che accada");
						this.genericCPs.Add ("Pensa a come far in modo che parte o tutto " + m_s_d + fillerLite + " si muovi e si regoli da solo");
						this.genericCPs.Add ("Pensa a come fare vibrare " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile far in modo che " + filler + " si cambi da solo, rilasci o assorbi energia");
						this.genericCPs.Add ("Pensa se è possibile fare " + filler + " in una forma irregolare");
						this.genericCPs.Add ("Pensa a cercar di mettere " + filler + " all'interno di un'altra cosa");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più sferico o circolare");
						this.genericCPs.Add ("Pensa a rendere tutte le parti " + m_s_d + fillerLite + " di una sostanza sola");
						this.genericCPs.Add ("Pensa a dividere " + filler + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " trasparente o di un colore diverso");
						this.genericCPs.Add ("Pensa a come fare in modo che " + filler + " si espanda o contragga  a seconda dell'ambiente");
						this.genericCPs.Add ("Pensa a come mettere buchi " + m_s_n + fillerLite + " o riempire i buchi " + m_s_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " a basso costo ed usa e getta");
						this.genericCPs.Add ("Pensa a far in modo che " + filler + " pulsi");
						this.genericCPs.Add ("Pensa a metter " + filler + " in un aspirapolvere");
						this.genericCPs.Add ("Pensa a disattivare " + filler + "");
						this.genericCPs.Add ("Pensa ad uniformare le forze ambientali che influenzano " + filler + "");
					}
					else if (filler.StartsWith ("i ", StringComparison.Ordinal) || filler.StartsWith ("gli ", StringComparison.Ordinal)) { // masculine plural Determiners
						this.genericCPs.Add ("Pensa a come far " + filler + " muoversi e regolarsi");
						this.genericCPs.Add ("Pensa a fare il contrario di ciò che è previsto con " + filler + "");
						this.genericCPs.Add ("Pensa se puoi sostituire qualcosa di meccanico " + m_p_n + fillerLite + " con qualcosa che è sensoriale");
						this.genericCPs.Add ("Pensa se è possibile modificare la densità " + m_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa se è possibile variare la temperatura " + m_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più flessibile");
						this.genericCPs.Add ("Pensa a come utilizzare liquidi o aria con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile rigenerare " + filler + "");
						this.genericCPs.Add ("Pensa a come fornire una conchiglia o copertura per " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile fare una copia " + m_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come si potrebbe combinare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa se potessi fare di piu' con " + filler + " o di meno con " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile bilanciare " + filler + " con qualcos'altro");
						this.genericCPs.Add ("Pensa a come far funzionare " + filler + " prima che sia necessario");
						this.genericCPs.Add ("Pensa a come far fare  " + m_p_a + fillerLite + " un sacco di cose diverse");
						this.genericCPs.Add ("Pensa a come introdurre feedback " + m_p_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a come far " + filler + " autosufficiente, in modo che utilizzino tutti i loro rifiuti");
						this.genericCPs.Add ("Pensa a come rimuovere qualcosa " + m_p_d + fillerLite + "");
						this.genericCPs.Add ("Pensa a come evitare lo stress " + m_p_n + fillerLite + ", e/o la situazione, prima che accada");
						this.genericCPs.Add ("Pensa a come far in modo che parte o tutto " + m_p_d + fillerLite + " si muovi e si regoli da solo");
						this.genericCPs.Add ("Pensa a come fare vibrare " + filler + "");
						this.genericCPs.Add ("Pensa se è possibile far in modo che " + filler + " si cambino da soli, rilascino o assorbino energia");
						this.genericCPs.Add ("Pensa se è possibile fare " + filler + " in una forma irregolare");
						this.genericCPs.Add ("Pensa a cercar di mettere " + filler + " all'interno di un'altra cosa");
						this.genericCPs.Add ("Pensa a rendere " + filler + " più sferici o circolari");
						this.genericCPs.Add ("Pensa a rendere tutte le parti " + m_p_d + fillerLite + " di una sostanza sola");
						this.genericCPs.Add ("Pensa a dividere " + filler + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " trasparente o di un colore diversi");
						this.genericCPs.Add ("Pensa a come fare in modo che " + filler + " si espandano o contraggano  a seconda dell'ambiente");
						this.genericCPs.Add ("Pensa a come mettere buchi " + m_p_n + fillerLite + " o riempire i buchi " + m_p_n + fillerLite + "");
						this.genericCPs.Add ("Pensa a rendere " + filler + " a basso costo ed usa e getta");
						this.genericCPs.Add ("Pensa a far in modo che " + filler + " pulsino");
						this.genericCPs.Add ("Pensa a metter " + filler + " in un aspirapolvere");
						this.genericCPs.Add ("Pensa a disattivare " + filler + "");
						this.genericCPs.Add ("Pensa ad uniformare le forze ambientali che influenzano " + filler + "");
					}

				}  
				else if (type.Equals ("VP")) {
					this.genericCPs.Add ("Pensa a utilizzare materiali che sono composti da molte cose durante " + filler + "");
					this.genericCPs.Add ("Pensa a come accelerare il " + filler + "");
					this.genericCPs.Add ("Pensa se è possibile ripetere il " + filler + "");
					this.genericCPs.Add ("Pensa se è possibile utilizzare un messaggero di qualsiasi forma in collaborazione con " + filler + "");
					this.genericCPs.Add ("Pensa a come introdurre feedback durante il " + filler + "");
					this.genericCPs.Add ("Pensa a rendere il " + filler + " autosufficiente, in modo che ricicla tutti i suoi rifiuti");
					this.genericCPs.Add ("Pensa a come rimuovere un passo dal " + filler + "");
					this.genericCPs.Add ("Pensa a avere un piano di emergenza in atto per " + filler + "");
					this.genericCPs.Add ("Pensa a come distribuire il " + filler + "");
					this.genericCPs.Add ("Pensa a come aggiungere o utilizzare una dimensione extra durante il " + filler + "");
					this.genericCPs.Add ("Pensa a come arricchire l'ambiente in cui " + filler + " avviene");
					this.genericCPs.Add ("Pensa a far pulsare qualcosa durante il " + filler + "");
					this.genericCPs.Add ("Pensa a uniformare le forze ambientali che si verificano durante il " + filler + "");
				}
				else
					this.genericCPs.Add ("");
			}
				
		}


	}
}

