const videos = [
    {
        id: 1,
        name: 'Video 1',
        duration: 11,
    },
    {
        id: 2,
        name: 'Video 2',
        duration: 11,
    },
    {
        id: 3,
        name: 'Video 3',
        duration: 11,
    },
]

export function VideoList() {
    return (
        <>
            <h1>VideoList</h1>
            {
                videos.map((video) => {
                    return (
                        <div key={video.id}>
                            <p>{video.name}</p>
                            <p>{video.duration} мин.</p>
                            <button>Like!</button>
                        </div>
                    )
                })
            }
        </>
    )
}
