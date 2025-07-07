using System.Collections;
using UnityEngine;

// Klasa odpowiedzialna za spawnowanie (generowanie) zagro�e� na podstawie danych z konfiguracji fali.
public class ThreatSpawner : MonoBehaviour
{
    // Odniesienie do danych o fali ataku (lista prefab�w i op�nie� pomi�dzy ich pojawieniem si�).
    public WaveConfig waveConfig;

    // Miejsce na scenie, z kt�rego b�d� pojawia�y si� zagro�enia.
    public Transform spawnPoint;

    // Metoda Start uruchamia si� automatycznie przy starcie sceny.
    private void Start()
    {
        // Sprawdzamy, czy przypisano konfiguracj� fali.
        if (waveConfig != null)
        {
            // Je�li tak � uruchamiamy korutyn�, kt�ra obs�u�y pojawianie si� zagro�e� z op�nieniami.
            StartCoroutine(SpawnWaveCoroutine());
        }
        else
        {
            // Je�li nie � ostrze�enie w konsoli. Bez waveConfig nie mo�emy dzia�a�.
            Debug.LogWarning("Brak przypisanego WaveConfig!");
        }
    }

    // Korutyna odpowiedzialna za odtwarzanie jednej fali zagro�e�.
    private IEnumerator SpawnWaveCoroutine()
    {
        // Iterujemy po wszystkich prefabach zdefiniowanych w waveConfig.
        for (int i = 0; i < waveConfig.threats.Count; i++)
        {
            GameObject prefab = waveConfig.threats[i];      // Prefab zagro�enia (np. wirus, pakiet DDoS).
            float delay = waveConfig.spawnDelays[i];        // Czas oczekiwania przed pojawieniem si� tego prefab'a.

            // Sprawdzamy, czy prefab i punkt spawnu istniej�.
            if (prefab != null && spawnPoint != null)
            {
                // Tworzymy instancj� zagro�enia w pozycji spawnPoint, z domy�ln� rotacj�.
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);

                // Informacja debugowa w konsoli, przydatna do test�w.
                Debug.Log($"[SPAWN] {prefab.name} instancjonowany po {delay} sekundach.");
            }
            else
            {
                // Je�li brakuje prefab'u lub punktu � wypisz ostrze�enie.
                Debug.LogWarning("[SPAWN] Brakuje prefab'u lub punktu spawnu!");
            }

            // Czekamy okre�lon� liczb� sekund przed pojawieniem si� kolejnego zagro�enia.
            yield return new WaitForSeconds(delay);
        }

        // Gdy wszystkie zagro�enia w fali zosta�y odtworzone � wypisujemy komunikat.
        Debug.Log($"[WAVE] Fala \"{waveConfig.waveName}\" zako�czona.");
    }
}
