select s.id, s.Name [Scene Name], d.Name [Device Name], ds.CommandName, ds.Parameters
from DeviceStates ds
	inner join Scenes s on s.Id = ds.DbSceneId
	inner join Devices d on d.Id = ds.DeviceId
order by s.Name, ds.ExecutionOrder

select * from scenes

select * from devices
