# ServerLogViewer
Small server log viewer


TEST C# Log Viewer


El log file tiene varias entradas de tipo diferente.

Algunas de tipo “A”
2019-11-13 09:25:16.8311|DEBUG|CciServer.Wpf.ViewModels.MainViewModel|SetCurrentView: Init

Otras de tipo “B”
2019-11-13 09:25:50.8857|INFO|<LogViewer>|Received NOTIFICATION message from game5977 [game5977->CCI]
{
  "type": "notification",
  "message_id": "notify_game_started",
  "id": "ed49a528-6552-4e48-80fc-8b52f1e48503",
  "timestamp": "2019-11-13T09:25:50.0000876-8:00",
  "requestor_id": null,
  "payload": {
    "game_id": "Fsx2018",
    "game_instance_id": 8612,
    "game_name": "FSX 2018"
  }
}

Otras tipos de rows …NO nos interesan

UI:
- Puede ser una WPF Windows app o un Website
- Un área donde pueda hacer Drag/Drop de un “.txt” file (acepta solo .txt)
- Un label de Status
- Un label de Version
- Un label de Date
- Una Table que tenga 5 columas
	Time / Delta / EventName / FromTo / Payload


 
LOG CONTENT TYPES:
- Procesando rows de tipo “A”
Popula TIME / Delta / EventName , deja vacio FromTo / Payload

- Procesando Rows de tipo “B”
https://prntscr.com/pwnn62
Time: es la primera flecha roja. Muestra hasta los milisegundos.
Delta: es la diferencia entre el row precedente …y el actual
El primer row seria vacio ya que no se puede comparar con un row anterior
EventName; es el valor de “message_id”
Payload: as veces está vacío, a veces tiene 1 o más. Si hay más de una, muestra todo en un single line con el “|” como separador.

REQUIREMENTS:
Cada vez que haga un Drop de un Log File, el sistema tiene que 
- Clear current table + labels
- Status label display “loading..”
- Inmediatamente load el file
- Status label display “processing…”
- Version label va llenado con el primer row del log sin los ** **
- Date label va llenado con el date que esta en el segundo row del log 
- Processar las info del log
- Display values on Table AS YOU PROCESS THEM
- Status label display “Loaded XXX records”  (where XXX son el numero de rows en la tabela)

>> NADA TIENE QUE SER HARD CODED

EJEMPLO OUTPUT

Version: CCI Server v2.15.7.0-g8d95d4f
Date: Logging started @ 2019/11/13 09:25:16.862

TIME	DELTA	EVENT NAME	FROM - TO	PAYLOAD
2019-11-13 09:25:16.8311	 (none) because no previous row	SetCurrentView: Init		
2019-11-13 09:25:50.885	33.9461	notify_game_started	game5977->CCI	game_id: Fsx2018 | game_instance_id:  8612 | game_name: FSX 2018


