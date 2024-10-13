public class MachineACafe {

	// enum des etats :
	// par état, différencier les actions possibles
	private enum Etat {
		IDLE {
			public void selectionnerBoisson(ToucheBoisson toucheBoisson, MachineACafe machine) {
				machine.afficherPasAssez(toucheBoisson);
			}

			public void rendreMonnaie (MachineACafe machine) {
				machine.afficherRetour();
			}
		},
		COLLECTE,
		PAS_ASSEZ {
			public void entrerMonnaie(Piece piece, MachineACafe machine) {
				machine.montantEnCours += piece.getValeur();
				machine.afficherMontant();
				// si le montant est suffisant, on déclenche la préparation de la boisson
				// sinon, on reste dans l'état PAS_ASSEZ
				if (machine.boisson.getPrix() > machine.montantEnCours) {
					machine.afficherPasAssez(machine.boisson);
				} else {
					machine.montantEnCours -= machine.boisson.getPrix();
					machine.afficherBoisson(machine.boisson);
					machine.boisson = null;
					machine.afficherMontant();
					if (machine.montantEnCours == 0)
						machine.setState(Etat.IDLE);
					else
						machine.etatCourant = COLLECTE;
				}
			}

			public void selectionnerBoisson(ToucheBoisson toucheBoisson, MachineACafe machine) {
				throw new IllegalStateException("Pas assez d'argent");
			}

			public void rendreMonnaie(MachineACafe machine) {
				machine.afficherRetour();
			}
		};
	};

	// on rajoute le state aux attributs de la machine
	private Etat etatCourant = Etat.IDLE;
	// et méthode get/set (ici juste set nécessaire)

	//public final int idle = 0;
	//public final int collecte = 1;
	//public final int pasAssez = 2;
	
	private int montantEnCours = 0;
	//private int etatCourant = idle;
	private ToucheBoisson boisson = null;
	
	public void afficherMontant() {
		System.out.println(montantEnCours + " cents disponibles");
	}
	
	public void afficherRetour() {
		System.out.println(montantEnCours + " cents rendus");
	}
	
	public void afficherPasAssez(ToucheBoisson toucheBoisson) {
		System.out.println("Vous n'avez pas introduit un montant suffisant pour un " + toucheBoisson);
		System.out.println("Il manque encore " + (toucheBoisson.getPrix() - montantEnCours) + " cents");
	}

	public void afficherBoisson(ToucheBoisson toucheBoisson) {
		System.out.println("Voici un " + toucheBoisson);
		
	}

	public void entrerMonnaie(Piece piece) {
		montantEnCours += piece.getValeur();
		afficherMontant();
		if ( etatCourant != Etat.PAS_ASSEZ)
			etatCourant = Etat.COLLECTE;
		else if (boisson.getPrix() > montantEnCours) {
				afficherPasAssez(boisson);
		} else {
			montantEnCours -= boisson.getPrix();
			afficherBoisson(boisson);
			boisson = null;
			afficherMontant();
			if (montantEnCours == 0)
				etatCourant =  Etat.IDLE;
			else
				etatCourant =  Etat.COLLECTE;
		}
	}
	
	public void selectionnerBoisson(ToucheBoisson toucheBoisson) {
		if (etatCourant == Etat.PAS_ASSEZ)
			throw new IllegalStateException();
		if (etatCourant == Etat.IDLE) {
			afficherPasAssez(toucheBoisson);
			return;			
		}
		if (toucheBoisson.getPrix() > montantEnCours) {
			boisson = toucheBoisson;
			afficherPasAssez(boisson);
			boisson = toucheBoisson;
			etatCourant =  Etat.PAS_ASSEZ;
			return;
		}
		montantEnCours -= toucheBoisson.getPrix();
		afficherBoisson(toucheBoisson);
		afficherMontant();
		if (montantEnCours == 0)
			etatCourant = Etat.IDLE;
		else
			etatCourant = Etat.COLLECTE;
	}
	
	public void rendreMonnaie() {
		if (etatCourant != Etat.IDLE) {
			afficherRetour();
			montantEnCours = 0;
			boisson = null;
		}
		etatCourant = Etat.IDLE;
	}

	public void setState(Etat etat) {
		this.etatCourant = etat;
	}
}
