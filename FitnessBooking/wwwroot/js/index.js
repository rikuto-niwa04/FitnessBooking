document.addEventListener('DOMContentLoaded', function () {
    const el = document.getElementById('calendar');
    if (!el) return;

    const calendar = new FullCalendar.Calendar(el, {
        initialView: 'dayGridMonth',
        locale: 'ja',
        timeZone: 'local',
        height: 'auto',
        headerToolbar: {
            start: 'title',
            center: '',
            end: 'today prev,next'
        },
        // まずは固定のサンプルイベント
        events: [
            {
                id: 'e1',
                title: '体験トレーニング（丹羽）',
                start: '2025-09-13T10:00:00',
                end: '2025-09-13T11:00:00',
                backgroundColor: '#0d6efd',
                borderColor: '#0d6efd'
            },
            {
                id: 'e2',
                title: 'パーソナル（佐藤）',
                start: '2025-09-18T19:30:00',
                end: '2025-09-18T20:30:00',
                backgroundColor: '#20c997',
                borderColor: '#20c997'
            }
        ],
        // クリックで軽く動作確認
        eventClick: (info) => {
            const s = info.event.start;
            const e = info.event.end;
            alert(
                `${info.event.title}\n` +
                `${s?.toLocaleString()} ～ ${e?.toLocaleString() || ''}`
            );
        }
    });

    calendar.render();
});