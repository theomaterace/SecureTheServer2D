using System.Collections;
using UnityEngine;

// Klasa odpowiedzialna za spawnowanie (generowanie) zagro¿eñ na podstawie danych z konfiguracji fali.
public class ThreatSpawner : MonoBehaviour
{
    // Odniesienie do danych o fali ataku (lista prefabów i opóŸnieñ pomiêdzy ich pojawieniem siê).
    public WaveConfig waveConfig;

    // Miejsce na scenie, z którego bêd¹ pojawia³y siê zagro¿enia.
    public Transform spawnPoint;

    // Metoda Start uruchamia siê automatycznie przy starcie sceny.
    private void Start()
    {
        // Sprawdzamy, czy przypisano konfiguracjê fali.
        if (waveConfig != null)
        {
            // Jeœli tak — uruchamiamy korutynê, która obs³u¿y pojawianie siê zagro¿eñ z opóŸnieniami.
            StartCoroutine(SpawnWaveCoroutine());
        }
        else
        {
            // Jeœli nie — ostrze¿enie w konsoli. Bez waveConfig nie mo¿emy dzia³aæ.
            Debug.LogWarning("Brak przypisanego WaveConfig!");
        }
    }

    // Korutyna odpowiedzialna za odtwarzanie jednej fali zagro¿eñ.
    private IEnumerator SpawnWaveCoroutine()
    {
        // Iterujemy po wszystkich prefabach zdefiniowanych w waveConfig.
        for (int i = 0; i < waveConfig.threats.Count; i++)
        {
            GameObject prefab = waveConfig.threats[i];      // Prefab zagro¿enia (np. wirus, pakiet DDoS).
            float delay = waveConfig.spawnDelays[i];        // Czas oczekiwania przed pojawieniem siê tego prefab'a.

            // Sprawdzamy, czy prefab i punkt spawnu istniej¹.
            if (prefab != null && spawnPoint != null)
            {
                // Tworzymy instancjê zagro¿enia w pozycji spawnPoint, z domyœln¹ rotacj¹.
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);

                // Informacja debugowa w konsoli, przydatna do testów.
                Debug.Log($"[SPAWN] {prefab.name} instancjonowany po {delay} sekundach.");
            }
            else
            {
                // Jeœli brakuje prefab'u lub punktu — wypisz ostrze¿enie.
                Debug.LogWarning("[SPAWN] Brakuje prefab'u lub punktu spawnu!");
            }

            // Czekamy okreœlon¹ liczbê sekund przed pojawieniem siê kolejnego zagro¿enia.
            yield return new WaitForSeconds(delay);
        }

        // Gdy wszystkie zagro¿enia w fali zosta³y odtworzone — wypisujemy komunikat.
        Debug.Log($"[WAVE] Fala \"{waveConfig.waveName}\" zakoñczona.");
    }
}
