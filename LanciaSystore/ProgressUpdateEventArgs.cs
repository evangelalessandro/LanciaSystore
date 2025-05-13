// Classe per i dati dell'evento
using System;

public class ProgressUpdateEventArgs : EventArgs {
	public int Percentage { get; }
	public string Message { get; }

	public ProgressUpdateEventArgs(int percentage, string message = "") {
		Percentage = percentage;
		Message = message;
	}
}


